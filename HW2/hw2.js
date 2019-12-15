// changes form color onclick
function formColor(x) {
  x.style.background = '#6b0000';
}

// answer shown when button is clicked
function getAnswer() {
  document.getElementById("answer").innerHTML = "<br>Ned Stark";
}

function getTitle() {
	var charTitle;
	switch(Math.floor(Math.random() * 5)) {
		 case 0:
         charTitle = "Mother of Dragons";
		 break;
		 case 1:
		 charTitle = "Queenslayer";
		 break;
		 case 2:
         charTitle = "Warden of the North";
		 break;
		 case 3:
		 charTitle = "First Sword of Braavos";
		 break;
		 case 4:
         charTitle = "Master of Whisperers";
		 break;
		}
	return charTitle;
}

function getStrength(age, number) {
	var total = ((Number(age) + Number(number)) / Number(3));

	if (total >= 44.5) {
		return 100;
	}
	else if (total >= 33) {
		return 75;
	}
	else if (total >= 16.5) {
		return 50;
	}
	else 
		return 25;

	return total;
}

function getIntelligence(age, number) {
	var total = ((Number(age) + Number(number)) / Number(3));

	if (total >= 44.5) {
		return 25;
	}
	else if (total >= 33) {
		return 50;
	}
	else if (total >= 16.5) {
		return 75;
	}
	else 
		return 100;

	return total;
}

function getAllegiance(age, number) {
	var total = ((Number(age) + Number(number)) / Number(3));

	if (total >= 44.5) {
		return 50;
	}
	else if (total >= 33) {
		return 100;
	}
	else if (total >= 16.5) {
		return 75;
	}
	else 
		return 25;

	return total;
}

function getSurvival(charStrength, charIntelligence, charAllegiance) {
	var result = Number(charStrength) + Number(charIntelligence) + Number(charAllegiance);

	if (result >= 240) {
		return "100%";
	}
	else if (result >= 180) {
		return "75%";
	}
	else if (result >= 120) {
		return "50%";
	}
	else if (result >= 60) {
		return "25%"
	}
	else 
		return "You're already dead.";
}

/* function to generate a character
*  checks if all parameters met
*  calls other functions to generate some result
*  opens new window to display results
*/
function generateCharacter(name, age, number) {

if (name == "" || age == "" || number == "") {
alert("Please fill required fields");
}
else {
// split up work of character generatios into separate functions	
var charTitle = getTitle();
var charStrength = getStrength(age, number);
var charIntelligence = getIntelligence(age, number);
var charAllegiance = getAllegiance(age, number);
var charSurvival = getSurvival(charStrength, charIntelligence, charAllegiance);

var win = window.open("", "", "width=270,height=350");
win.document.write("<p><b>Character Name:</b></p> " + name + ", " + charTitle);
win.document.write("<p><b>Strength:</b></p> " + charStrength + "/100");
win.document.write("<p><b>Intelligence:</b></p> " + charIntelligence + "/100");
win.document.write("<p><b>Allegiance:</b></p> " + charAllegiance + "/100");
win.document.write("<p><b>Chances of Survial:</b></p> " + charSurvival);
    }
} 

$(document).ready(function () {
    $(".btn1").click(function () {
        $("#hidediv1").hide();
        $("#showingdiv1").show();
    });
});

$(document).ready(function () {
    $(".btn2").click(function () {
        $("#hidediv2").hide();
        $("#showingdiv2").show();
    });
});

$(document).ready(function () {
    $(".btn3").click(function () {
        $("#hidediv3").hide();
        $("#showingdiv3").show();
    });
});

$(document).ready(function () {
    $(".btn4").click(function () {
        $("#hidediv4").hide();
        $("#showingdiv4").show();
    });
});

$(document).ready(function () {
    $(".btn5").click(function () {
        $("#hidediv5").hide();
        $("#showingdiv5").show();
    });
});

$(document).ready(function () {
    $(".btn6").click(function () {
        $("#hidediv6").hide();
        $("#showingdiv6").show();
    });
});

$(document).ready(function () {
    $(".btn7").click(function () {
        $("#hidediv7").hide();
        $("#showingdiv7").show();
    });
});

$(document).ready(function () {
    $(".btn8").click(function () {
        $("#hidediv8").hide();
        $("#showingdiv8").show();
    });
});

$(document).ready(function () {
    $(".btn9").click(function () {
        $("#hidediv9").hide();
        $("#showingdiv9").show();
    });
});

$(document).ready(function () {
    $(".btn10").click(function () {
        $("#hidediv10").hide();
        $("#showingdiv10").show();
    });
});

// several functions that randomly choose trivia
// and append to table using jQuery
function InsertElements(character)
{
	if (character == 'Missandei')
	{
		switch(Math.floor(Math.random() * 10)) {
		  case 0:
            var markup = "<tr><td>Origin: Naath, Sothoryos</td></tr>";
            $(tbody1).append(markup);
		    break;
		  case 1:
            var markup = "<tr><td>Allegiance: House Targaryen</td></tr>";
            $(tbody1).append(markup);
		    break;
		  case 2:
            var markup = "<tr><td>Good Masters (former slave)</td></tr>";
            $(tbody1).append(markup);
		    break;
		  case 3:
            var markup = "<tr><td>Culture: Naathi</td></tr>";
            $(tbody1).append(markup);
		    break;
		  case 4:
            var markup = "<tr><td>Partner: Grey Worm</td></tr>";
            $(tbody1).append(markup);
		    break;
		  case 5:
            var markup = "<tr><td>Actor: Nathalie Emmanuel</td></tr>";
            $(tbody1).append(markup);
		    break;
		  case 6:
            var markup = "<tr><td>First seen: Valar Dohaeris</td></tr>";
            $(tbody1).append(markup);
		    break;
		  case 7:
            var markup = "<tr><td>Last seen: The Last of the Starks</td></tr>";
            $(tbody1).append(markup);
		    break;
		  case 8:
            var markup = "<tr><td>Status: Deceased</td></tr>";
            $(tbody1).append(markup);
		    break;
		  case 9:
            var markup = "<tr><td>Confidant of Daenerys</td></tr>";
            $(tbody1).append(markup);
		    break;
		}
	}

	else if (character == 'Arya' )
	{
		switch(Math.floor(Math.random() * 10)) {
		  case 0:
            var markup = "<tr><td>Titles: Princess</td></tr>";
            $(tbody2).append(markup);
		    break;
		  case 1:
            var markup = "<tr><td>Nickname: Arry</td></tr>";
            $(tbody2).append(markup);
		    break;
		  case 2:
            var markup = "<tr><td>Nickname: Mercy</td></tr>";
            $(tbody2).append(markup);
		    break;
		  case 3:
            var markup = "<tr><td>Nickname: Hero of Winterfell</td></tr>";
            $(tbody2).append(markup);
		    break;
		  case 4:
            var markup = "<tr><td>Origin: Winterfell</td></tr>";
            $(tbody2).append(markup);
		    break;
		  case 5:
            var markup = "<tr><td>Culture: Northmen</td></tr>";
            $(tbody2).append(markup);
		    break;
		  case 6:
            var markup = "<tr><td>Culture: Braavost</td></tr>";
            $(tbody2).append(markup);
		    break;
		  case 7:
            var markup = "<tr><td>Allegiance: House Stark</td></tr>";
            $(tbody2).append(markup);
		    break;
		  case 8:
            var markup = "<tr><td>Allegiance: Faceless Men</td></tr>";
            $(tbody2).append(markup);
		    break;
		  case 9:
            var markup = "<tr><td>Father: Eddard Stark</td></tr>";
            $(tbody2).append(markup);
		    break;
		}
	}

	else if (character == 'Tyrion' )
	{
		switch(Math.floor(Math.random() * 10)) {
		  case 0:
            var markup = "<tr><td>Nickname: The Little Lion</td></tr>";
            $(tbody3).append(markup);
		    break;
		  case 1:
            var markup = "<tr><td>Nickname: The Imp</td></tr>";
            $(tbody3).append(markup);
		    break;
		  case 2:
            var markup = "<tr><td>Nickname: The Halfman</td></tr>";
            $(tbody3).append(markup);
		    break;
		  case 3:
            var markup = "<tr><td>Allegiance: House Lannister</td></tr>";
            $(tbody3).append(markup);
		    break;
		  case 4:
            var markup = "<tr><td>Origin: Casterly Rock</td></tr>";
            $(tbody3).append(markup);
		    break;
		  case 5:
            var markup = "<tr><td>Allegiance: House Targaryen</td></tr>";
            $(tbody3).append(markup);
		    break;
		  case 6:
            var markup = "<tr><td>Culture: Andal</td></tr>";
            $(tbody3).append(markup);
		    break;
		  case 7:
            var markup = "<tr><td>Father: Tywin Lannister</td></tr>";
            $(tbody3).append(markup);
		    break;
		  case 8:
            var markup = "<tr><td>Mother: Joanna Lannister</td></tr>";
            $(tbody3).append(markup);
		    break;
		  case 9:
            var markup = "<tr><td>Actor: Peter Dinklage</td></tr>";
            $(tbody3).append(markup);
		    break;
		}
	}

	else if (character == 'Dany' ) {
		switch(Math.floor(Math.random() * 10)) {
		  case 0:
            var markup = "<tr><td>Origin: Dragonstone</td></tr>";
            $(tbody4).append(markup);
		    break;
		  case 1:
            var markup = "<tr><td>Raised: Free Cities</td></tr>";
            $(tbody4).append(markup);
		    break;
		  case 2:
            var markup = "<tr><td>Allegiance: House Targaryen</td></tr>";
            $(tbody4).append(markup);
		    break;
		  case 3:
            var markup = "<tr><td>Culture: Valyrian</td></tr>";
            $(tbody4).append(markup);
		    break;
		  case 4:
            var markup = "<tr><td>Father: Aerys II Targaryen</td></tr>";
            $(tbody4).append(markup);
		    break;
		  case 5:
            var markup = "<tr><td>Mother: Rhaella Targaryen</td></tr>";
            $(tbody4).append(markup);
		    break;
		  case 6:
            var markup = "<tr><td>Spouse: Drogo</td></tr>";
            $(tbody4).append(markup);
		    break;
		  case 7:
            var markup = "<tr><td>Nickname: Daenerys Stormborn</td></tr>";
            $(tbody4).append(markup);
		    break;
		  case 8:
            var markup = "<tr><td>Nickname: The Dragon Queen</td></tr>";
            $(tbody4).append(markup);
		    break;
		  case 9:
            var markup = "<tr><td>Mother of Dragons</td></tr>";
            $(tbody4).append(markup);
		    break;
		}
	}

	else if (character == 'Jorah' )
	{
		switch(Math.floor(Math.random() * 10)) {
		  case 0:
            var markup = "<tr><td>First seen: Winter is Coming</td></tr>";
            $(tbody5).append(markup);
		    break;
		  case 1:
            var markup = "<tr><td>Title: Ser</td></tr>";
            $(tbody5).append(markup);
		    break;
		  case 2:
            var markup = "<tr><td>Title: Lord of Bear Island</td></tr>";
            $(tbody5).append(markup);
		    break;
		  case 3:
            var markup = "<tr><td>Origin: Bear Island</td></tr>";
            $(tbody5).append(markup);
		    break;
		  case 4:
            var markup = "<tr><td>Allegiance: House Targaryen</td></tr>";
            $(tbody5).append(markup);
		    break;
		  case 5:
            var markup = "<tr><td>Queensguard</td></tr>";
            $(tbody5).append(markup);
		    break;
		  case 6:
            var markup = "<tr><td>Culture: Northmen</td></tr>";
            $(tbody5).append(markup);
		    break;
		  case 7:
            var markup = "<tr><td>Religion: Old Gods of the Forest</td></tr>";
            $(tbody5).append(markup);
		    break;
		  case 8:
            var markup = "<tr><td>Father: Jeor Mormont</td></tr>";
            $(tbody5).append(markup);
		    break;
		  case 9:
            var markup = "<tr><td>Actor: Iain Glen</td></tr>";
            $(tbody5).append(markup);
		    break;
		}
	}

	else if (character == 'Sansa' )
	{
		switch(Math.floor(Math.random() * 10)) {
		  case 0:
            var markup = "<tr><td>Queen in the North</td></tr>";
            $(tbody6).append(markup);
		    break;
		  case 1:
            var markup = "<tr><td>Lady of Winterfell</td></tr>";
            $(tbody6).append(markup);
		    break;
		  case 2:
            var markup = "<tr><td>Nickname: Little Dove</td></tr>";
            $(tbody6).append(markup);
		    break;
		  case 3:
            var markup = "<tr><td>Nickname: Little Bird</td></tr>";
            $(tbody6).append(markup);
		    break;
		  case 4:
            var markup = "<tr><td>Origin: Winterfell</td></tr>";
            $(tbody6).append(markup);
		    break;
		  case 5:
            var markup = "<tr><td>Allegiance: House Stark</td></tr>";
            $(tbody6).append(markup);
		    break;
		  case 6:
            var markup = "<tr><td>Culture: Northmen</td></tr>";
            $(tbody6).append(markup);
		    break;
		  case 7:
            var markup = "<tr><td>Father: Eddard Stark</td></tr>";
            $(tbody6).append(markup);
		    break;
		  case 8:
            var markup = "<tr><td>Mother: Catelyn Stark</td></tr>";
            $(tbody6).append(markup);
		    break;
		  case 9:
            var markup = "<tr><td>Actor: Sophie Turner</td></tr>";
            $(tbody6).append(markup);
		    break;
		}
     }

	else if (character == 'Cersei' ) {
		switch(Math.floor(Math.random() * 10)) {
		  case 0:
            var markup = "<tr><td>Queen of the Andals and the First Men</td></tr>";
            $(tbody7).append(markup);
		    break;
		  case 1:
            var markup = "<tr><td>Protector of the Seven Kingdoms</td></tr>";
            $(tbody7).append(markup);
		    break;
		  case 2:
            var markup = "<tr><td>Origin: Casterly Rock</td></tr>";
            $(tbody7).append(markup);
		    break;
		  case 3:
            var markup = "<tr><td>Allegiance: House Lannister</td></tr>";
            $(tbody7).append(markup);
		    break;
		  case 4:
            var markup = "<tr><td>Culture: Andal</td></tr>";
            $(tbody7).append(markup);
		    break;
		  case 5:
            var markup = "<tr><td>Father: Tywin Lannister</td></tr>";
            $(tbody7).append(markup);
		    break;
		  case 6:
            var markup = "<tr><td>Mother: Joanna Lannister</td></tr>";
            $(tbody7).append(markup);
		    break;
		  case 7:
            var markup = "<tr><td>Child: Joffrey Baratheon</td></tr>";
            $(tbody7).append(markup);
		    break;
		  case 8:
            var markup = "<tr><td>Child: Myrcella Baratheon</td></tr>";
            $(tbody7).append(markup);
		    break;
		  case 9:
            var markup = "<tr><td>Child: Tommen Baratheon</td></tr>";
            $(tbody7).append(markup);
		    break;
		}
     }

	else if (character == 'Jaime' ) {
		switch(Math.floor(Math.random() * 10)) {
		  case 0:
            var markup = "<tr><td>Title: Ser</td></tr>";
            $(tbody8).append(markup);
		    break;
		  case 1:
            var markup = "<tr><td>Origin: Casterly Rock</td></tr>";
            $(tbody8).append(markup);
		    break;
		  case 2:
            var markup = "<tr><td>Allegiance: House Lannister</td></tr>";
            $(tbody8).append(markup);
		    break;
		  case 3:
            var markup = "<tr><td>Predecessor: Barristan Selmy</td></tr>";
            $(tbody8).append(markup);
		    break;
		  case 4:
            var markup = "<tr><td>Successor: Brienne of Tarth</td></tr>";
            $(tbody8).append(markup);
		    break;
		  case 5:
            var markup = "<tr><td>Culture: Andal</td></tr>";
            $(tbody8).append(markup);
		    break;
		  case 6:
            var markup = "<tr><td>Actor: Nikolaj Coster-Waldau</td></tr>";
            $(tbody8).append(markup);
		    break;
		  case 7:
            var markup = "<tr><td>Sibling: Cersei Lannister</td></tr>";
            $(tbody8).append(markup);
		    break;
		  case 8:
            var markup = "<tr><td>Sibling: Tyrion Lannister</td></tr>";
            $(tbody8).append(markup);
		    break;
		  case 9:
            var markup = "<tr><td>Father: Tywin Lannister</td></tr>";
            $(tbody8).append(markup);
		    break;
		}
     }

	else if (character == 'Jon' ) {
		switch(Math.floor(Math.random() * 10)) {
		  case 0:
            var markup = "<tr><td>Warden of the North</td></tr>";
            $(tbody9).append(markup);
		    break;
		  case 1:
            var markup = "<tr><td>King in the North</td></tr>";
            $(tbody9).append(markup);
		    break;
		  case 2:
            var markup = "<tr><td>Lord Commander of the Night's Watch</td></tr>";
            $(tbody9).append(markup);
		    break;
		  case 3:
            var markup = "<tr><td>The Bastard of Winterfell</td></tr>";
            $(tbody9).append(markup);
		    break;
		  case 4:
            var markup = "<tr><td>King Crow</td></tr>";
            $(tbody9).append(markup);
		    break;
		  case 5:
            var markup = "<tr><td>The Prince That Was Promised</td></tr>";
            $(tbody9).append(markup);
		    break;
		  case 6:
            var markup = "<tr><td>Origin: Tower of Joy</td></tr>";
            $(tbody9).append(markup);
		    break;
		  case 7:
            var markup = "<tr><td>Raised: Winterfell</td></tr>";
            $(tbody9).append(markup);
		    break;
		  case 8:
            var markup = "<tr><td>Religion: Old Gods of the North</td></tr>";
            $(tbody9).append(markup);
		    break;
		  case 9:
            var markup = "<tr><td>Actor: Kit Harrington</td></tr>";
            $(tbody9).append(markup);
		    break;
		}
     }

	else if (character == 'Brienne' ) {
		switch(Math.floor(Math.random() * 10)) {
		  case 0:
            var markup = "<tr><td>Title: Ser</td></tr>";
            $(tbody10).append(markup);
		    break;
		  case 1:
            var markup = "<tr><td>Lord Commander of the Kingsguard</td></tr>";
            $(tbody10).append(markup);
		    break;
		  case 2:
            var markup = "<tr><td>Lady Brienne</td></tr>";
            $(tbody10).append(markup);
		    break;
		  case 3:
            var markup = "<tr><td>Origin: Evenfall Hall</td></tr>";
            $(tbody10).append(markup);
		    break;
		  case 4:
            var markup = "<tr><td>Allegiance: House Tarth</td></tr>";
            $(tbody10).append(markup);
		    break;
		  case 5:
            var markup = "<tr><td>Culture: Andal</td></tr>";
            $(tbody10).append(markup);
		    break;
		  case 6:
            var markup = "<tr><td>Religion: Faith of the Seven</td></tr>";
            $(tbody10).append(markup);
		    break;
		  case 7:
            var markup = "<tr><td>Father: Selwyn Tarth</td></tr>";
            $(tbody10).append(markup);
		    break;
		  case 8:
            var markup = "<tr><td>Actor: Gwendoline Christie</td></tr>";
            $(tbody10).append(markup);
		    break;
		  case 9:
            var markup = "<tr><td>Predecessor: Jaime Lannister</td></tr>";
            $(tbody10).append(markup);
		    break;
		}
     }	
}
