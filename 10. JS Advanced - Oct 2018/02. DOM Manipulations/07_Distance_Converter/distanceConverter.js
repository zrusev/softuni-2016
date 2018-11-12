function attachEventsListeners() {
  document.getElementById('convert').addEventListener('click', (e) => {
    const units = ['km', 'm', 'cm', 'mm', 'mi', 'yrd', 'ft', 'in'];

    let inputUnitValue = +document.getElementById('inputDistance').value;

    let inputUnitIndex = document.getElementById('inputUnits').selectedIndex;
    let outputUnitIndex = document.getElementById('outputUnits').selectedIndex;

    let inputUnit = units[inputUnitIndex];
    let outputUnit = units[outputUnitIndex];

    let inpUnit = convertToMeters(inputUnitValue, inputUnit);
    let outputUnitValue = convertFromMeters(inpUnit, outputUnit);

    document.getElementById('outputDistance').value = outputUnitValue;

    function convertToMeters(val, unit) {
      switch (unit) {
        case 'km':
          return val * 1000;
        case 'm':
          return val;
        case 'cm':
          return val * 0.01;
        case 'mm':
          return val * 0.001;
        case 'mi':
          return val * 1609.34;
        case 'yrd':
          return val * 0.9144;
        case 'ft':
          return val * 0.3048;
        case 'in':
          return val * 0.0254;
      }
    }

    function convertFromMeters(val, unit) {
      switch (unit) {
        case 'km':
          return val / 1000;
        case 'm':
          return val;
        case 'cm':
          return val / 0.01;
        case 'mm':
          return val / 0.001;
        case 'mi':
          return val / 1609.34;
        case 'yrd':
          return val / 0.9144;
        case 'ft':
          return val / 0.3048;
        case 'in':
          return val / 0.0254;
      }
    }
  });
}