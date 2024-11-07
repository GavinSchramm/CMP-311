const Joi = require('joi');
const express = require('express');
const { valid, validate } = require('joi/lib/types/lazy');
const app = express();

app.use(express.json());

const coins = [
    {id: 1, year: 1890, type: "penny", isRare: true},
    {id: 2, year: 2000, type: "quarter", isRare: false},
    {id: 3, year: 1776, type: "half dollar", isRare: true}
];

app.get('/', (req, res) => {
    res.send("Hello World!!!");
});

app.get('/api/coins', (req, res) => {
    res.send(coins);
});

app.post('/api/coins', (req, res) => {
    const { error } = validatecoin(req.body);
    if (error) return res.status(400).send(error.details[0].message)

    const coin = {
        id: coins.length + 1,
        year: req.body.year,
        type: req.body.type,
        isRare: req.body.isRare
    };
    coins.push(coin);
    res.send(coin);
});

app.put('/api/coins/:id', (req, res) => {
    const coin = coins.find(c => c.id === parseInt(req.params.id));
    if (!coin) return res.status(404).send('The coin with the given ID was not found.');
        
    const { error } = validatecoin(req.body);
    if (error) return res.status(400).send(error.details[0].message);

    coin.year = req.body.year;
    coin.type = req.body.type;
    coin.isRare = req.body.isRare;
    res.send(coin);
});

app.delete('/api/coins/:id', (req, res) => {
    const coin = coins.find(c => c.id === parseInt(req.params.id))
    if (!coin) return res.status(404).send('The coin with the given ID was not found.')

    const index = coins.indexOf(coin);
    coins.splice(index, 1);

    res.send(coin);
});

function validatecoin(coin) {
    const schema = {
        year: Joi.required(),
        type: Joi.string().required(),
        isRare: Joi.required()
    };

    return Joi.validate(coin, schema)
}

app.get('/api/coins/:id', (req, res) => {
    const coin = coins.find(c => c.id === parseInt(req.params.id))
    if (!coin) return res.status(404).send('The coin with the given ID was not found.')
        res.send(coin);
});

const port = process.env.PORT || 3000;
app.listen(port, () => console.log(`Listening on port ${port}...`));