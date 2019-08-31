import '../../styles/views/index.scss';
import '../../styles/views/index.css';

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