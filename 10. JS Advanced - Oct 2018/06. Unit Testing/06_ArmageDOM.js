let expect = require('chai').expect;
let jsdom = require('jsdom-global')();
let $ = require('jquery');

function nuke(selector1, selector2) {
  if (selector1 === selector2) {
    return;
  }

  $(selector1)
    .filter(selector2)
    .remove();
}

describe.only("function nuke", function () {
  let htmlSelector;
  let oldHtml;

  beforeEach(() => {
    document.body.innerHTML =
      `<div id="target">
                <div class="nested target">
                    <p>This is some text</p>
                </div>
                <div class="target">
                    <p>Empty div</p>
                </div>
                <div class="inside">
                    <span class="nested">Some more text</span>
                    <span class="target">Some <span>more</span> text</span>
                </div>
            </div>`

    htmlSelector = $('#target');
    oldHtml = htmlSelector.html();
  });

  before(() => global.$ = $);

  it("Should not remove with an invalid selector", function () {
    let oldHtml = $(htmlSelector).html();
    nuke(htmlSelector, 5);
    expect(htmlSelector.html()).to.be.equal(oldHtml);
  });

  it("should not remove with duplicate selector", function () {
    let selector1 = $('.nested');
    nuke(selector1, selector1);

    expect(htmlSelector.html()).to.be.equal(oldHtml);
  });

  it("should not remove with two valid selectors", function () {
    let selector1 = $('.nested');
    let selector2 = $('.inside');
    nuke(selector1, selector2);

    expect(htmlSelector.html()).to.be.equal(oldHtml);
  });

  it("should remove with valid selectors", function () {
    let selector1 = $('.nested');
    let selector2 = $('.target');
    nuke(selector1, selector2);

    expect(htmlSelector.html()).to.not.be.equal(oldHtml);
  });
});