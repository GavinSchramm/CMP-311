var mysql = require('mysql2');

var con = mysql.createConnection({
  host: "localhost",
  user: "root",
  password: "Schramm",
  database: "final"
});

con.connect(function(err) {
    if (err) throw err;
    console.log("Connected!");
    var sql = "CREATE TABLE course (courseId int NOT NULL AUTO_INCREMENT, courseNumber VARCHAR(255), courseName VARCHAR(255), facultyId VARCHAR(255), enrollmentLimit VARCHAR(255), PRIMARY KEY (courseId))";
    con.query(sql, function (err, result) {
      if (err) throw err;
      console.log("Table made");
    });
});