//When deleting a faculty, check to make sure they are not in a course
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
var facultyList = []
var courseList = []


//Fills the courseList and facultyList
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

//Faculty end points
app.get('/', (req, res) => {
    res.send("The end point is\n/api/faculty");
});

//read
app.get('/api/faculty', (req, res) => {
    con.connect(function(err) {
        if (err) throw err;
        con.query("SELECT * FROM faculty", function (err, result, fields) {
          if (err) throw err;
          res.send(result);
        });
    });
});

//read one item
app.get('/api/faculty/:id', (req, res) => {
    id = req.params.id
    verify = CheckId(id)
    if (verify){
        con.connect(function(err) {
            if (err) throw err;
            con.query("SELECT * FROM faculty WHERE facultyId = '" + id + "'", function (err, result, fields) {
                if (err) throw err;
                res.send(result)
            });
        });
    } else {
        res.send("Id not valid")
    }
});

//post
app.post('/api/faculty', (req, res) => {
    facultyFirstName = req.body.firstName
    facultyLastName = req.body.lastName
    facultyEmail = req.body.email
    con.connect(function(err) {
        if (err) throw err;
        var sql = "INSERT INTO faculty (lastName, firstName, email) VALUES ('" + facultyFirstName + "', '" + facultyLastName + "', '" + facultyEmail + "')";
        con.query(sql, function (err, result) {
          if (err) throw res.send(err);
          res.send("Faculty Added");
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
});

//update
app.put('/api/faculty/:id', (req, res) => {
    facultyFirstName = req.body.firstName
    facultyLastName = req.body.lastName
    facultyEmail = req.body.email
    id = req.params.id
    myStr = ""

    verify = CheckId(id)
    if (verify){
        con.connect(function(err) {
            if (err) throw err;
            var sql = "UPDATE faculty SET firstName = '" + facultyFirstName + "', lastName = '" + facultyLastName + "',email = '" + facultyEmail + "' WHERE facultyId = '" + id + "'";
            con.query(sql, function (err, result) {
                if (err) throw err;
                res.send("Faculty Added");
            });
        });
    } else {
        res.send("Id not valid")
    }
});

//delete
app.delete('/api/faculty/:id', (req, res) => {
    id = req.params.id

    verify = CheckId(id)
    if (verify){
        verify = CheckBeforeDelete(id)
        if (!verify){
            con.connect(function(err) {
                if (err) throw err;
                var sql = "DELETE FROM faculty WHERE facultyId = '" + id + "'";
                con.query(sql, function (err, result) {
                    if (err) throw err;
                    res.send("Faculty deleted");
                });
            });
        } else {
            res.send("Faculty is teaching")
        }
    } else {
        res.send("Id not valid")
    }
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
});


//to let you know what port to connect to
const port = process.env.PORT || 3000;
app.listen(port, () => console.log(`Listening on port ${port}...`));


//id validation
function CheckId(id, table) {
    for (let j = 0; j < facultyList.length; j++){
        if (facultyList[j] == id) {
            return true
        }
    }
    return false
}

function CheckBeforeDelete(id){
    for (let i = 0; i < courseList.length; i++){
        if (courseList[i] == id){
            return true
        }
    }
    return false
}