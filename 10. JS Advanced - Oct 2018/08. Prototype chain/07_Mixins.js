function createMixins() {
  function computerQualityMixin(classToExtend) {
    let computerQualityMixin = {
      getQuality() {
        return (this.processorSpeed + this.ram + this.hardDiskSpace) / 3;
      },
      isFast() {
        return this.processorSpeed > (this.ram / 4);
      },
      isRoomy() {
        return this.hardDiskSpace > Math.floor(this.ram * this.processorSpeed);
      }
    };

    Object.assign(classToExtend.prototype, computerQualityMixin);
  }

  function styleMixin(classToExtend) {
    let styleMixin = {
      isFullSet() {
        return this.manufacturer === this.keyboard.manufacturer && this.keyboard.manufacturer === this.monitor.manufacturer;
      },
      isClassy() {
        return this.battery.expectedLife >= 3 && (this.color === "Silver" || this.color === "Black") &&
          this.weight < 3;
      }
    };

    Object.assign(classToExtend.prototype, styleMixin);
  }

  return {
    computerQualityMixin,
    styleMixin
  }
}