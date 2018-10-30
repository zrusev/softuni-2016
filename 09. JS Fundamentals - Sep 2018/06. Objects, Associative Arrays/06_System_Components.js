function sysComponents (input) {
  let systems = new Map();
  for (let i = 0; i < input.length; i++) {
    let [system, component, subComponent] = input[i].split(" | ");
    
    if(!systems.has(system)) {
      systems.set(system, new Map());
    }

    if(!systems.get(system).get(component)) {
      systems.get(system).set(component, []);
    }

    systems.get(system).get(component).push(subComponent);    
  }

  let sortedSystems = Array.from(systems.keys()).sort()
    .sort((a, b) => systems.get(b).size - systems.get(a).size);

  for(let key of sortedSystems) {
    console.log(key);
    
    let sortedComponents = Array.from(systems.get(key).keys())
      .sort((a, b) => systems.get(key).get(b).length - systems.get(key).get(a).length);

    for(let item of sortedComponents) {
      console.log(`|||${item}`);
      
      for(let subComponents of systems.get(key).get(item)) {
        console.log(`||||||${subComponents}`);
      }
    }
  }
 }

sysComponents(['SULS | Main Site | Home Page',
'SULS | Main Site | Login Page',
'SULS | Main Site | Register Page',
'SULS | Judge Site | Login Page',
'SULS | Judge Site | Submittion Page',
'Lambda | CoreA | A23',
'SULS | Digital Site | Login Page',
'Lambda | CoreB | B24',
'Lambda | CoreA | A24',
'Lambda | CoreA | A25',
'Lambda | CoreC | C4',
'Indice | Session | Default Storage',
'Indice | Session | Default Security']
)