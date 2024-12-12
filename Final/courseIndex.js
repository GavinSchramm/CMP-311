const express = require('express');
const app = express();

var mysql = require('mysql2');

var con = mysql.createConnection( {
    host: "localhost",
    user: "root",
    password: "Schramm",
    database: "final"
});

app.use(express.json());

let verify = false;
var courseList = []
var facultyList = []

//fill courseList and facultyList
con.connect(function(err) {
    courseList = []
    if (err) throw err;
    con.query("SELECT * FROM course", function (err, result, fields) {
        if (err) throw err;
        for (let i = 0; i < result.length; i++) {
            courseList[i] = result[i]["courseId"]
        }
    });
});

con.connect(function(err) {
    facultyList = []
    if (err) throw err;
    con.query("SELECT * FROM faculty", function (err, result, fields) {
        if (err) throw err;
        for (let i = 0; i < result.length; i++) {
            facultyList[i] = result[i]["facultyId"]
        }
    });
});

//course end points
app.get('/', (req, res) => {
    res.send("The end point is\n/api/course");
});

//read
app.get('/api/course', (req, res) => {
    con.connect(function(err) {
        if (err) throw err;
        con.query("SELECT * FROM course", function (err, result, fields) {
          if (err) throw err;
          res.send(result);
        });
    });
});

//read one item
app.get('/api/course/:id', (req, res) => {
    id = req.params.id
    verify = CheckId(id)
    if (verify){
        con.connect(function(err) {
            if (err) throw err;
            con.query("SELECT * FROM course WHERE courseId = '" + id + "'", function (err, result, fields) {
                if (err) throw err;
                res.send(result)
            });
        });
    } else {
        res.send("Id not valid")
    }
});

//post
app.post('/api/course', (req, res) => {
    courseNumber = req.body.courseNumber
    courseName = req.body.courseName
    facultyId = req.body.facultyId
    enrollmentLimit = req.body.enrollmentLimit
    facultyVerify = CheckFaculty(facultyId)
    if (facultyVerify){
        con.connect(function(err) {
            if (err) throw err;
            var sql = "INSERT INTO course (courseNumber, courseName, facultyId, enrollmentLimit) VALUES ('" + courseNumber + "', '" + courseName + "', '" + facultyId + "', '" + enrollmentLimit + "')";
            con.query(sql, function (err, result) {
            if (err) throw res.send(err);
            res.send("Course Added");
            });
        });
        con.connect(function(err) {
            courseList = []
            if (err) throw err;
            con.query("SELECT * FROM course", function (err, result, fields) {
                if (err) throw err;
        
                for (let i = 0; i < result.length; i++) {
                    courseList[i] = result[i]["courseId"]
                }
            });
        });
    } else {
        res.send("Invalid Faculty Id")
    }
});

//update
app.put('/api/course/:id', (req, res) => {
    courseNumber = req.body.courseNumber
    courseName = req.body.courseName
    facultyId = req.body.facultyId
    enrollmentLimit = req.body.enrollmentLimit
    id = req.params.id

    verify = CheckId(id)
    facultyVerify = CheckFaculty(facultyId)
    if (verify){
        if (facultyVerify){
            con.connect(function(err) {
                if (err) throw err;
                var sql = "UPDATE course SET courseNumber = '" + courseNumber + "', courseName = '" + courseName + "', facultyId = '" + facultyId + "', enrollmentLimit = '" + enrollmentLimit + "' WHERE courseId = '" + id + "'";
                con.query(sql, function (err, result) {
                    if (err) throw err;
                    res.send("Course Updated");
                });
            });
        } else {
            res.send("Invalid Faculty Id")
        }
    } else {
        res.send("Id not valid")
    }
});

//delete
app.delete('/api/course/:id', (req, res) => {
    id = req.params.id

    verify = CheckId(id)
    if (verify){
        con.connect(function(err) {
            if (err) throw err;
            var sql = "DELETE FROM course WHERE courseId = '" + id + "'";
            con.query(sql, function (err, result) {
                if (err) throw err;
                res.send("Course deleted");
            });
        });
    } else {
        res.send("Id not valid")
    }
    con.connect(function(err) {
        courseList = []
        if (err) throw err;
        con.query("SELECT * FROM course", function (err, result, fields) {
            if (err) throw err;
    
            for (let i = 0; i < result.length; i++) {
                courseList[i] = result[i]["courseId"]
            }
        });
    });
});


//to let you know what port to connect to
const port = process.env.PORT || 3000;
app.listen(port, () => console.log(`Listening on port ${port}...`));


//id validation
function CheckId(id) {
    for (let j = 0; j < courseList.length; j++){
        if (courseList[j] == id) {
            return true
        }
    }
    return false
}

function CheckFaculty(facultyId) {
    for (let i = 0; i < facultyList.length; i++){
        if (facultyList[i] == parseInt(facultyId)) {
            return true
        }
    }
    return false
}