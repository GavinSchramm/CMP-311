var mysql = require('mysql2');

var con = mysql.createConnection({
  host: "localhost",
  user: "root",
  password: "Schramm",
  database: "mydb"
});

con.connect(function(err) {
    if (err) throw err;
    /*Select all customers where the address starts with an "S":*/
    con.query("SELECT * FROM customers WHERE address LIKE 'S%'", function (err, result) {
      if (err) throw err;
      console.log(result);
    });
  });