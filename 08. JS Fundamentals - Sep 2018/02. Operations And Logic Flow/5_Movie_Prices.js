 function moviePrices([title, day]) {
  const daysOfWeek = ['monday',	'tuesday',	'wednesday',	'thursday',	'friday',	'saturday',	'sunday'];
  
  const movies = {
     'the godfather' : [12,	10,	15,	12.50,	15,	25,	30],
     "schindler's list":  [8.50,	8.50,	8.50,	8.50,	8.50,	15,	15],
     'casablanca' : [8,	8,	8,	8,	8,	10,	10],
     'the wizard of oz' : [10,	10,	10,	10,	10,	15,	15]
     }

  try {
      let dayNumber = daysOfWeek.indexOf(day.toLowerCase());
      
      let choice = movies[title.toLowerCase()][dayNumber];

      if(choice !== undefined) {
        console.log(choice);
      } else {
        console.error('error');
      }
  } catch(error) {
      console.error('error');
  }
}

moviePrices(['The Godfather', 'Sofia']);