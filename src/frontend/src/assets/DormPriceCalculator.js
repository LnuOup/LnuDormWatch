/* All for request-admission.component.html */

/**
 * Reads data from date inputs and counts difference in days
 * @returns {number}
 */
function getNumberOfDays() {
  let a = document.getElementById("input_start_living");
  let b = document.getElementById("input_end_living");
  let d1 = new Date(a.value);
  let d2 = new Date(b.value);

  return Math.floor((d2 - d1) / (1000 * 60 * 60 * 24));
}

/**
 * Updates room type dropdown list depending on other options selected
 */
function updateAvailableRoomTypes() {
  if (document.getElementById("dropdown_dorms").value === "dorm1") {
    document.getElementById("dropdown_room_type").innerHTML =
      '<option value="lux">Люкс</option>' +
      '<option value="halflux">Напівлюкс</option>' +
      '<option value="single_bed">Одномісна</option>' +
      '<option value="two_beds">Двомісна</option>';
  } else if (document.getElementById("radio_guest").checked) {
    document.getElementById("dropdown_room_type").innerHTML =
      '<option value="simple">Проста</option>' +
      '<option value="better">Поліпшена</option>';
  } else {
    document.getElementById("dropdown_room_type").innerHTML =
      '<option value="simple">Проста</option>';
  }
}

/**
 * Calculates living price depending on values entered. This is the main function
 * @returns {number}
 */
function getLivingPrice() {
  /* All in UAH */
  const PRICE_PER_MONTH = 520; //For one bed

  const PRICE_PER_DAY_GUEST = 55; //For one bed
  const PRICE_PER_DAY_GUEST_BETTER_ROOM = 100; //For one bed
  const PRICE_PER_DAY_LUX = 1050; //For the whole room
  const PRICE_PER_DAY_HALF_LUX = 840; //For the whole room
  const PRICE_PER_DAY_1PLACE = 600; //For the whole room with one bed
  const PRICE_PER_DAY_2PLACES = 750; //For the whole room

  const MINIMAL_PRICE = 100; //UAH

  /* Coefficients */
  const PRICE_MODIFIER_ORPHAN = 0; // Free
  const PRICE_MODIFIER_ATO = 0.5; // -50%
  const PRICE_MODIFIER_BLAT = 0.9; // -10%

  var price;

  let dormName = document.getElementById("dropdown_dorms").value;
  let roomType = document.getElementById("dropdown_room_type").value;
  if (dormName === "dorm1") {
    switch (roomType) {
      case "single_bed":
        price = PRICE_PER_DAY_1PLACE * getNumberOfDays();
        break;
      case "two_beds":
        price = PRICE_PER_DAY_2PLACES * getNumberOfDays();
        break;
      case "halflux":
        price = PRICE_PER_DAY_HALF_LUX * getNumberOfDays();
        break;
      case "lux":
      default:
        price = PRICE_PER_DAY_LUX * getNumberOfDays();
        break;
    }
  } else if (document.getElementById("radio_guest").checked) {
    switch (roomType) {
      case "better":
        price = PRICE_PER_DAY_GUEST_BETTER_ROOM * getNumberOfDays();
        break;
      case "simple":
      default:
        price = PRICE_PER_DAY_GUEST * getNumberOfDays();
        break;
    }
  } else { //TODO Only full months are allowed
    price = Math.ceil(PRICE_PER_MONTH * getNumberOfDays() / 30);
  }

  //Types of discount
  if (document.getElementById("checkbox_orphan").checked) {
    price *= PRICE_MODIFIER_ORPHAN;
  }
  if (document.getElementById("checkbox_ATO").checked) {
    price *= PRICE_MODIFIER_ATO;
  }
  if (document.getElementById("checkbox_blat").checked) {
    price *= PRICE_MODIFIER_BLAT;
  }

  return price; //Math.max(price, MINIMAL_PRICE);
}

/**
 * Same as getLivingPrice(), but handles NaN and negative values and adds 'UAH' to the output
 */
function getLivingPriceHandled() {
  const price = getLivingPrice();
  let result;
  if (isNaN(price) || price < 0) {
    result = "Помилка!\nОберіть коректні дати";
  }
  else {
    result = price + " UAH";
  }
  return result;
}

