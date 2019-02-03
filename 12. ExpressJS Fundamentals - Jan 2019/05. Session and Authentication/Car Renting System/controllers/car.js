const Car = require('../models/Car');
const Rent = require('../models/Rent');

module.exports = {
    addGet: (req, res) => {
        res.render('car/add');
    },
    addPost: (req, res) => {
        const carBody = req.body;

        if (!carBody.model || !carBody.image || !carBody.pricePerDay) {
            carBody.error = 'Fill the required fields!';
            res.render('car/add', carBody);
            return;
        }

        Car.create({
            model: carBody.model,
            image: carBody.image,
            pricePerDay: carBody.pricePerDay,
            isRented: carBody.isRented
        }).then(() => {
            res.redirect('/car/all');
        }).catch((err) => {
            console.log(err);
            carBody.error = 'Something went wrong!';
            res.render('car/add', carBody);
            return;
        })
    },
    allCars: (req, res) => {
        Car.find({
                'isRented': false
            })
            .then((cars) => {
                res.render('car/all', {
                    cars
                });
            }).catch((err) => {
                console.log(err);
            });
    },
    search: (req, res) => {
        const search = req.query.model;

        if (search === '') {
            res.render('car/all');
            return;
        }

        const query = Car.find({
            $or: [{ model: new RegExp(search, 'i') }, { pricePerDay: isNaN(search) ? 0 : parseInt(search) }],
            isRented: false
        })
        .limit(20);

        query.exec((err, cars) => {
            if (err) {
                console.log(err);
                return;
            }

            res.render('car/all', { cars });
        });
    },
    rentGet: (req, res) => {
        Car.findById(req.params.id)
            .then((car) => {
                res.render('car/rent', car);
            })
            .catch((err) => {
                console.log(err);
            });
    },
    rentPost: async (req, res) => {
        const carId = req.params.id;
        const userId = req.user._id;
        const days = parseInt(req.body.days);

        try {
            const car = await Car.findById(carId);
            car.isRented = true;
            await car.save();

            const rent = await Rent.create({
                days,
                car: carId,
                owner: userId
            });
            await rent.save();

            res.redirect('/car/all');
        } catch (err) {
            console.log(err);
        }
    },
    editGet: (req, res) => {
        Car.findById(req.params.id)
            .then((car) => {
                res.render('car/edit', car);
            })
            .catch((err) => {
                console.log(err);
            });
    },
    editPost: async (req, res) => {
        const carBody = req.body;

        if (!carBody.model || !carBody.image || !carBody.pricePerDay) {
            carBody.error = 'Fill the required fields!';
            res.render('car/add', carBody);
            return;
        }
        try {
            const car = await Car.findById(req.params.id);

            if (!car) {
                carBody.error = 'Car not found!';
                res.render('car/edit', carBody);
                return;
            }

            car.model = carBody.model;
            car.image = carBody.image;
            car.pricePerDay = carBody.pricePerDay;
            await car.save();

            res.redirect('/car/all');
            return;
        } catch (err) {
            console.log(err);
        }
    }
}