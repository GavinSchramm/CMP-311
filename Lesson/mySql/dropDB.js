// WARNING
// WILL DELETE EVERYTHING DATABASE RELATED

var mysql = require('mysql2');

var con = mysql.createConnection({
  host: "localhost",
  user: "root",
  password: "Schramm",
  database: "mydb"
});

con.connect(function(err) {
  if (err) throw err;
  var sql = "DROP DATABASE mydb";
  con.query(sql, function (err, result) {
    if (err) throw err;
    console.log("Database deleted");
  });
});