var lineReader = require('readline').createInterface({
	input: require('fs').createReadStream('input.txt')
});

var max = 0;
var registers = {};

lineReader.on('line', function (line) {
	var instructions = line.split(" ");
	
	var register = instructions[0];
	var op = instructions[1];
	var change = parseInt(instructions[2]);
	var condReg = instructions[4];
	var condition = instructions[5] + " " + instructions[6];

	if(registers[condReg] == undefined) {
		registers[condReg] = 0;
	}

	if(registers[register] == undefined) {
		registers[register] = 0;
	}

	if(eval(registers[condReg] + " " + condition)) {
		if(op == "inc") {
			registers[register] += change;
		} else if(op == "dec") {
			registers[register] -= change;
		}
	}

	for (var key in registers) {
		if(registers[key] > max) {
			max = registers[key];
		}
	}

	console.log("Global max: " + max);

	printMax(registers);
});

function printMax(obj) {
	var max = 0;
	for (var key in obj) {
		if(obj[key] > max) {
			max = obj[key];
		}
	}
	console.log("Current max: " + max);
}