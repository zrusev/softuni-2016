import '../../styles/views/index.scss';

function helloPromise() {
    return new Promise((resolve, reject) => {                
        try {
            resolve(console.log('Hello World!'));            
        } catch (error) {
            reject(console.log(error));
        }
    });
}

helloPromise();