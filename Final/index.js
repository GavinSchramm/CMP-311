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
var studentList = []
var facultyList = []
var courseList = []

//Fills the student, faculty, and course list
con.connect(function(err) {
    studentList = []
    if (err) throw err;
    con.query("SELECT * FROM student", function (err, result, fields) {
        if (err) throw err;
        for (let i = 0; i < result.length; i++) {
            studentList[i] = result[i]["studentId"]
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

//Student end points
//read
app.get('/', (req, res) => {
    res.send("The end points is\n/api/student\n/api/faculty\n/api/course");
});

app.get('/api/student', (req, res) => {
    con.connect(function(err) {
        if (err) throw err;
        con.query("SELECT * FROM student", function (err, result, fields) {
          if (err) throw err;
          res.send(result);
        });
    });
});

//read one item
app.get('/api/student/:id', (req, res) => {
    id = req.params.id
    verify = CheckStudentId(id)
    if (verify){
        con.connect(function(err) {
            if (err) throw err;
            con.query("SELECT * FROM student WHERE studentId = '" + id + "'", function (err, result, fields) {
                if (err) throw err;
                res.send(result)
            });
        });
    } else {
        res.send("Id not valid")
    }
});

//post
app.post('/api/student', (req, res) => {
    studentFirstName = req.body.firstName
    studentLastName = req.body.lastName
    studentEmail = req.body.email
    con.connect(function(err) {
        if (err) throw err;
        var sql = "INSERT INTO student (lastName, firstName, email) VALUES ('" + studentFirstName + "', '" + studentLastName + "', '" + studentEmail + "')";
        con.query(sql, function (err, result) {
          if (err) throw res.send(err);
          res.send("Student Added");
        });
    });
    con.connect(function(err) {
        studentList = []
        if (err) throw err;
        con.query("SELECT * FROM student", function (err, result, fields) {
            if (err) throw err;
            for (let i = 0; i < result.length; i++) {
                studentList[i] = result[i]["studentId"]
            }
        });
    });
});

//update
app.put('/api/student/:id', (req, res) => {
    studentFirstName = req.body.firstName
    studentLastName = req.body.lastName
    studentEmail = req.body.email
    id = req.params.id

    verify = CheckStudentId(id)
    if (verify){
        con.connect(function(err) {
            if (err) throw err;
            var sql = "UPDATE student SET firstName = '" + studentFirstName + "', lastName = '" + studentLastName + "',email = '" + studentEmail + "' WHERE studentId = '" + id + "'";
            con.query(sql, function (err, result) {
                if (err) throw err;
                res.send("Student Updated");
            });
        });
    } else {
        res.send("Id not valid")
    }
});

//delete
app.delete('/api/student/:id', (req, res) => {
    id = req.params.id

    verify = CheckStudentId(id)
    if (verify){
        con.connect(function(err) {
            if (err) throw err;
            var sql = "DELETE FROM student WHERE studentId = '" + id + "'";
            con.query(sql, function (err, result) {
                if (err) throw err;
                res.send("Student deleted");
            });
        });
    } else {
        res.send("Id not valid")
    }
    con.connect(function(err) {
        studentList = []
        if (err) throw err;
        con.query("SELECT * FROM student", function (err, result, fields) {
            if (err) throw err;
    
            for (let i = 0; i < result.length; i++) {
                studentList[i] = result[i]["studentId"]
            }
        });
    });
});


//id validation
function CheckStudentId(id) {
    for (let j = 0; j < studentList.length; j++){
        if (studentList[j] == id) {
            return true
        }
    }
    return false
}









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
    verify = CheckFacultyId(id)
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

    verify = CheckFacultyId(id)
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

    verify = CheckFacultyId(id)
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



//id validation
function CheckFacultyId(id, table) {
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
    verify = CheckCourseId(id)
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
    facultyVerify = CheckFacultyId(facultyId)
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

    verify = CheckCourseId(id)
    facultyVerify = CheckFacultyId(facultyId)
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

    verify = CheckCourseId(id)
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


//id validation
//If the id parameter is in the respected list, returns true
function CheckCourseId(courseId) {
    for (let j = 0; j < courseList.length; j++){
        if (courseList[j] == courseId) {
            return true
        }
    }
    return false
}

function CheckFacultyId(facultyId) {
    for (let i = 0; i < facultyList.length; i++){
        if (facultyList[i] == parseInt(facultyId)) {
            return true
        }
    }
    return false
}

function checkStudentId(studentId) {
    for (let i = 0; i < studentList.length; i++){
        if (studentList[i] == parseInt(studentId)) {
            return true
        }
    }
    return false
}

//to let you know what port to connect to
const port = process.env.PORT || 3000;
app.listen(port, () => console.log(`Listening on port ${port}...`));