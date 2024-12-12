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
var idList = []

con.connect(function(err) {
    idList = []
    if (err) throw err;
    con.query("SELECT * FROM student", function (err, result, fields) {
        if (err) throw err;

        for (let i = 0; i < result.length; i++) {
            idList[i] = result[i]["studentId"]
        }
    });
});

//Student end points
//read
app.get('/', (req, res) => {
    res.send("The end points is\n/api/student");
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
    verify = CheckId(id)
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
        idList = []
        if (err) throw err;
        con.query("SELECT * FROM student", function (err, result, fields) {
            if (err) throw err;
    
            for (let i = 0; i < result.length; i++) {
                idList[i] = result[i]["studentId"]
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
    myStr = ""

    verify = CheckId(id)
    if (verify){
        con.connect(function(err) {
            if (err) throw err;
            var sql = "UPDATE student SET firstName = '" + studentFirstName + "' WHERE studentId = '" + id + "'";
            con.query(sql, function (err, result) {
                if (err) throw err;
                myStr = myStr + "First name, ";
            });
        });
        con.connect(function(err) {
            if (err) throw err;
            var sql = "UPDATE student SET lastName = '" + studentLastName + "' WHERE studentId = '" + id + "'";
            con.query(sql, function (err, result) {
                if (err) throw err;
                myStr = myStr + "last name, "
            });
        });
        con.connect(function(err) {
            if (err) throw err;
            var sql = "UPDATE student SET email = '" + studentEmail + "' WHERE studentId = '" + id + "'";
            con.query(sql, function (err, result) {
                if (err) throw err;
                myStr = myStr + "and email updated.";
                res.send(myStr);
            });
        });
    } else {
        res.send("Id not valid")
    }
});

//delete
app.delete('/api/student/:id', (req, res) => {
    id = req.params.id

    verify = CheckId(id)
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
        idList = []
        if (err) throw err;
        con.query("SELECT * FROM student", function (err, result, fields) {
            if (err) throw err;
    
            for (let i = 0; i < result.length; i++) {
                idList[i] = result[i]["studentId"]
            }
        });
    });
});

//to let me know what port to connect to
const port = process.env.PORT || 3000;
app.listen(port, () => console.log(`Listening on port ${port}...`));

//id validation
function CheckId(id) {
    for (let j = 0; j < idList.length; j++){
        if (idList[j] == id) {
            return true
        }
    }
    return false
}