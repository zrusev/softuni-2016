let assert = require('chai').assert;
let expect = require('chai').expect;

class SoftUniFy {
  constructor() {
    this.allSongs = {};
  }

  downloadSong(artist, song, lyrics) {
    if (!this.allSongs[artist]) {
      this.allSongs[artist] = {
        rate: 0,
        votes: 0,
        songs: []
      }
    }

    this.allSongs[artist]['songs'].push(`${song} - ${lyrics}`);

    return this;
  }

  playSong(song) {
    let songArtists = Object.keys(this.allSongs).reduce((acc, cur) => {

      let songs = this.allSongs[cur]['songs']
        .filter((songInfo) => songInfo
          .split(/ - /)[0] === song);

      if (songs.length > 0) {
        acc[cur] = songs;
      }

      return acc;
    }, {});

    let arr = Object.keys(songArtists);
    let output = "";

    if (arr.length > 0) {

      arr.forEach((artist) => {
        output += `${artist}:\n`;
        output += `${songArtists[artist].join('\n')}\n`;
      });

    } else {
      output = `You have not downloaded a ${song} song yet. Use SoftUniFy's function downloadSong() to change that!`
    }

    return output;
  }

  get songsList() {
    let songs = Object.values(this.allSongs)
      .map((v) => v['songs'])
      .reduce((acc, cur) => {
        return acc.concat(cur);
      }, []);

    let output;

    if (songs.length > 0) {
      output = songs.join('\n');
    } else {
      output = 'Your song list is empty';
    }

    return output;

  }

  rateArtist() {
    let artistExist = this.allSongs[arguments[0]];
    let output;

    if (artistExist) {

      if (arguments.length === 2) {
        artistExist['rate'] += +arguments[1];
        artistExist['votes'] += 1;
      }

      let currentRate = (+(artistExist['rate'] / artistExist['votes']).toFixed(2));
      isNaN(currentRate) ? output = 0 : output = currentRate;

    } else {
      output = `The ${arguments[0]} is not on your artist list.`
    }

    return output;
  }
}

describe('SoftUniFy', function () {
  let instance;
  beforeEach('initialize class', () => {
    instance = new SoftUniFy();
  })

  it("should be initiate with two string arguments", () => {
    assert.instanceOf(instance, SoftUniFy, "Function did not return the correct result.");
  });

  it('should contain allSongs property', () => {
    assert.isObject(instance.allSongs, 'Function did not return the correct result.');
  });

  it('should contain allSongs property', () => {
    assert.include(instance.allSongs, Object, 'Function did not return the correct result.');
  });

  it('downloadSong(artist, song, lyrics) adds the given information', () => {
    instance.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
    instance.downloadSong('Eminem', 'Venom', 'Knock...');
    assert.include(instance.allSongs['Eminem'], Object, 'Function did not return the correct result.');
    assert.equal(instance.allSongs['Eminem'].rate, 0, 'Function did not return the correct result.');
    assert.equal(instance.allSongs['Eminem'].votes, 0, 'Function did not return the correct result.');
    assert.isArray(instance.allSongs['Eminem'].songs, 'Function did not return the correct result.');
    assert.equal(instance.allSongs['Eminem'].songs.toString(), 'Venom - Knock, Knock let the devil in...,Venom - Knock...');
  });

  it('playSong(song) searches all already downloaded songs', () => {
    let song = 'Song';
    assert.equal(instance.playSong(song), `You have not downloaded a ${song} song yet. Use SoftUniFy's function downloadSong() to change that!`, 'Function did not return the correct result.');
  });

  it('playSong(song) searches all already downloaded songs', () => {
    instance.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
    let song = 'Venom';
    assert.equal(instance.playSong(song), `Eminem:\nVenom - Knock, Knock let the devil in...\n`, 'Function did not return the correct result.');
  });

  it('songsList() gets all already downloaded songs ', () => {
    instance.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
    instance.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');
    assert.equal(instance.songsList, `Venom - Knock, Knock let the devil in...\nPhenomenal - IM PHENOMENAL...`, 'Function did not return the correct result.');
  });

  it('songsList() gets all already downloaded songs ', () => {
    assert.equal(instance.songsList, `Your song list is empty`, 'Function did not return the correct result.');
  });

  it('rateArtist() sums the values of all votes on the current artist and return the average rate', () => {
    assert.equal(instance.rateArtist('Eminem', 50), 'The Eminem is not on your artist list.', 'Function did not return the correct result.');
    assert.equal(instance.rateArtist('Eminem'), 'The Eminem is not on your artist list.', 'Function did not return the correct result.');
  });
});