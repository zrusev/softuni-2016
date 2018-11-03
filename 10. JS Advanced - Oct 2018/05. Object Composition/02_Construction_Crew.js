function fixWorker(workerObj) {
  if (!workerObj.handsShaking) {
    return Object.create(workerObj);
  }

  const newWorker = Object.create(workerObj);
  newWorker.bloodAlcoholLevel += 0.1 * newWorker.weight * newWorker.experience;
  newWorker.handsShaking = false;

  return newWorker;
}

let f = fixWorker({ weight: 80,
  experience: 1,
  bloodAlcoholLevel: 0,
  handsShaking: true }
)

for(let w in f) {
  console.log(`${w}`);
}

