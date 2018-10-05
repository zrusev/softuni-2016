function onGeneratedRow(columnsResult)
{
    var jsonData = {};

    for(let i = 0; i < columnsResult.length; i+= 2) {
      jsonData[columnsResult[i]] = columnsResult[i + 1];
    }

    console.log(jsonData);
 }

 onGeneratedRow(['name', 'Pesho', 'age', '23', 'gender', 'male']);