const Joi = require('joi');
const express = require('express');
const { valid, validate } = require('joi/lib/types/lazy');
const app = express();

var mysql = require('mysql2');

var idCount = 0

var con = mysql.createConnection( {
    host: "localhost",
    user: "root",
    password: "Schramm",
    database: "mydb"
});

app.use(express.json());

//to get id length
con.connect(function(err) {
    if (err) throw err;
    con.query("SELECT COUNT(*) FROM customers", function (err, result, fields) {
      if (err) throw err;
      temp = result[0];
      idCount = temp['COUNT(*)']
    });
});

//read
app.get('/', (req, res) => {
    res.send("Hello World!!!");
});

app.get('/api/customers', (req, res) => {
    con.connect(function(err) {
        if (err) throw err;
        con.query("SELECT * FROM customers", function (err, result, fields) {
          if (err) throw err;
          res.send(result);
        });
    });
});

//post
app.post('/api/customers', (req, res) => {
    customerName = req.body.name
    customerAddress = req.body.address
    idCount = parseInt(idCount) + 1
    con.connect(function(err) {
        if (err) throw err;
        console.log("Connected!");
        var sql = "INSERT INTO customers (name, address, id) VALUES ('" + customerName + "', '" + customerAddress + "', '" + idCount.toString() + "')";
        con.query(sql, function (err, result) {
          if (err) throw err;
          res.send("It worked, now get items");
        });
    });
});

//update
app.put('/api/customers/:id', (req, res) => {
    customerName = req.body.name
    customerAddress = req.body.address
    idCount = req.params.id.toString()
    myStr = ""
    con.connect(function(err) {
        if (err) throw err;
        var sql = "UPDATE customers SET name = '" + customerName + "' WHERE id = '" + idCount + "'";
        con.query(sql, function (err, result) {
            if (err) throw err;
            myStr = myStr + "Name updated, ";
        });
    });
    con.connect(function(err) {
        if (err) throw err;
        var sql = "UPDATE customers SET address = '" + customerAddress + "' WHERE id = '" + idCount + "'";
        con.query(sql, function (err, result) {
            if (err) throw err;
            myStr = myStr + "address updated"
            res.send(myStr);
        });
    });
});

//delete
app.delete('/api/customers/:id', (req, res) => {
    idCount = req.params.id.toString()
    con.connect(function(err) {
        if (err) throw err;
        var sql = "DELETE FROM customers WHERE id = '" + idCount + "'";
        con.query(sql, function (err, result) {
            if (err) throw err;
            res.send("Observation deleted");
        });
    });
});

//read one item
app.get('/api/customers/:id', (req, res) => {
    idCount = req.params.id.toString()
    con.connect(function(err) {
        if (err) throw err;
        con.query("SELECT * FROM customers WHERE id = '" + idCount + "'", function (err, result, fields) {
            if (err) throw err;
            res.send(result);
        });
    });
});

//to let me know what port to connect to
const port = process.env.PORT || 3000;
app.listen(port, () => console.log(`Listening on port ${port}...`));