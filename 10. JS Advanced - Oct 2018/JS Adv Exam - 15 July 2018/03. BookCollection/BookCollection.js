class BookCollection {
  constructor(shelfGenre, room, shelfCapacity) {

    if (["livingRoom", "bedRoom", "closet"].includes(room)) {
      this.shelfGenre = shelfGenre;
      this.room = room;
      this.shelfCapacity = shelfCapacity;
      this.shelf = [];
    } else {
      throw new Error(`"Cannot have book shelf in ${room}"`)
    }
  }

  get shelfCondition() {
    return this.shelfCapacity - this.shelf.length;
  }

  addBook(bookName, bookAuthor, genre = '') {
    let book = {
      bookName,
      bookAuthor,
      genre
    };

    if (this.shelf.length < this.shelfCapacity) {
      this.shelf.push(book);
    } else {
      let firstBook = this.shelf.shift();
      this.shelf.push(book);
    }

    let sorted = this.shelf.sort((a, b) => a.bookAuthor > b.bookAuthor);
    this.shelf = sorted;

    return this;
  }

  throwAwayBook(bookName) {
    let updatedShelf = this.shelf.filter((n) => n.bookName !== bookName);
    this.shelf = updatedShelf;

    return this;
  }

  showBooks(genre) {
    let filteredBooks = this.shelf.filter((b) => b.genre === genre);

    let result = `Results for search "${genre}":`;

    for (let book of filteredBooks) {
      result += `\n\uD83D\uDCD6 ${book.bookAuthor} - "${book.bookName}"`;
    }

    return result;
  }

  toString() {
    if (this.shelf.length === 0) {
      return `It's an empty shelf`;
    }

    let result = `"${this.shelfGenre}" shelf in ${this.room} contains:`;

    for (let book of this.shelf) {
      result += `\n\uD83D\uDCD6 "${book.bookName}" - ${book.bookAuthor}`;
    }

    return result;
  }
}

let bedRoom = new BookCollection('Programming', 'livingRoom', 5)
bedRoom.addBook("Introduction to Programming with C#", "Svetlin Nakov")
bedRoom.addBook("Introduction to Programming with Java", "Svetlin Nakov")
bedRoom.addBook("Programming for .NET Framework", "Svetlin Nakov");
console.log(bedRoom.toString());