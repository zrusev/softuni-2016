const storage = require('./storage');
const storageAsync = require('./storageAsync');

//////////////////////// All sync tests should pass //////////////////////////////////
storage.put('first', 'firstValue');
storage.put('second', 'secondValue');
storage.put('third', 'thirdValue');
storage.put('fouth', 'fourthValue');
console.log(storage.get('first'));
console.log(storage.getAll());
storage.delete('second');
storage.update('first', 'updatedFirst');
storage.save();
storage.clear();
console.log(storage.getAll());
storage.load();
console.log(storage.getAll());
//////////////////////////////////////////////////////////////////////////////////////

////////////////////// All sync tests should throw exceptions ////////////////////////
try {
    storage.put('first','firstValue');
} catch (error) {
    console.log(error);    
}

try {
    storage.put('second','secondValue');
} catch (error) {
    console.log(error);    
}

try {
    storage.delete('second');    
} catch (error) {
    console.log(error);    
}

try {
    storage.delete('second');    
} catch (error) {
    console.log(error);        
}

try {
    storage.put(2,'someValue');	    
} catch (error) {
    console.log(error); 
}

try {
    storage.put('cat','dog');    
} catch (error) {
    console.log(error);        
}

try {
    storage.put('cat','anotherDog');
} catch (error) {
    console.log(error);    
}
//////////////////////////////////////////////////////////////////////////////////////

//////////////////////// All async tests should pass //////////////////////////////////
(async () => {
    await storageAsync.load()
        .then(() => storageAsync.put('first', 'firstValue'))
        .then(() => storageAsync.put('second', 'secondValue'))
        .then(() => storageAsync.put('third', 'thirdValue'))
        .then(() => storageAsync.put('fouth', 'fourthValue'))
        .then(() => console.log(storageAsync.getAll()))
        .then(() => console.log(storageAsync.get('first')))
        .then(() => console.log(storageAsync.getAll()))
        .then(() => storageAsync.delete('second'))
        .then(() => storageAsync.update('first', 'updatedFirst'))
        .then(async () => await storageAsync.save())
        .then(() => console.log(storageAsync.getAll()))
        .then(() => storageAsync.clear())
        .then(() => console.log(storageAsync.getAll()))
        .then(async () => await storageAsync.load()
            .then(() => console.log(storageAsync.getAll()))
        );
}) ();
//////////////////////////////////////////////////////////////////////////////////////

//////////////////////// All аsync tests should throw exceptions /////////////////////
(async () => {
    await storageAsync.load()
        .then(() => storageAsync.put('first','firstValue'))
            .catch((err) => console.log(err))
        .then(() => storageAsync.put('second','secondValue'))
            .catch((err) => console.log(err))        
        .then(() => storageAsync.delete('second'))
            .catch((err) => console.log(err))            
        .then(() => storageAsync.delete('second'))
            .catch((err) => console.log(err))    
        .then(() => storageAsync.put(2,'someValue'))
            .catch((err) => console.log(err))    
        .then(() => storageAsync.put('cat','dog'))
            .catch((err) => console.log(err))    
        .then(() => storageAsync.put('cat','anotherDog'))
            .catch((err) => console.log(err));
}) ();
//////////////////////////////////////////////////////////////////////////////////////