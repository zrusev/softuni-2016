// function daysInMonth (month, year) {
//   return new Date(year, month, 0).getDate();
// }

// function dayOfWeek (day, month, year) {
//   let days = ['Sun','Mon','Tue','Wed','Thu','Fri','Sat'];
//   let d = new Date(year, month - 1, day, 0, 0, 0, 0);
//   return days[d.getDay()];
// }

// function dayOfWeekIndex (day, month, year) {
//   return new Date(year, month - 1, day, 0, 0, 0, 0).getDay();
// }

//SoftUni's judge allows only one function
function calendar([day, month, year]) {
  //let fs = require('fs');
  //split to elements

  let days = ['Sun','Mon','Tue','Wed','Thu','Fri','Sat'];
  let html = [];

  html.push('<table>\n<tr>');
  //print headers
  for(let i = 0; i< days.length; i++) {
    html.push(`<th>${days[i]}</th>`);
  }
  html.push('</tr>\n  <tr>');
  
  let dOneIndex = new Date(year, month - 1, 1, 0, 0, 0, 0).getDay();
  let totalDaysInPreviousMonth = new Date(year, month - 1, 0).getDate();

  let daysToStart = totalDaysInPreviousMonth - dOneIndex + 1;
  //print previous month days
  for(let i = daysToStart; i <= totalDaysInPreviousMonth; i++) {
    html.push(`<td class="prev-month">${i}</td>`);
  }

  //print current month days
  for(let i = 1; i <= 7 - dOneIndex; i++) {
    if(i === day) {
      html.push(`<td class="today">${i}</td>`);
    } else {
      html.push(`<td>${i}</td>`);
    }
  }

  html.push('</tr>\n  <tr>');

  let index = 7 - dOneIndex + 1;
  let totalNumberOfDaysInCurrentMonth = new Date(year, month, 0).getDate();
  let counter = 0;

  for(let i = index; i <= totalNumberOfDaysInCurrentMonth; i++) {
    if(counter % 7 == 0 && counter > 0) { 
      html.push('</tr>\n  <tr>');
    }

    if(i === day) {
      html.push(`<td class="today">${i}</td>`);
    } else {
      html.push(`<td>${i}</td>`);
    }
    
    counter++;
  }
  //print next month days
  let dLastIndex = new Date(year, month - 1, totalNumberOfDaysInCurrentMonth, 0, 0, 0, 0).getDay();

  counter = 1;
  for(let i = dLastIndex + 1; i < 7; i++) {
    html.push(`<td class="next-month">${counter}</td>`);

    counter++;
  }

  html.push('</tr>');

  html.push('\n</table>');

  // fs.writeFile('9_index.html', html.join(), function(err) {
  //   if(err) {
  //       return console.log(err);
  //   }
  // })
  return html.join('');
}

console.log(calendar([1, 1, 1900]));