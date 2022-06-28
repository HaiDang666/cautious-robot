var edge = require('edge-js');

// var hello = edge.func(function () {/*
//     async (input) => { 
//         return "CSharp welcomes " + input.ToString(); 
//     }
// */});

// hello('Node.js', function (error, result) {
//     if (error) throw error;
//     console.log(result);
// });

var add7 = edge.func('Sample105.dll');

add7(1, function (error, result) {
	if (error) throw error;
	console.log("add7", result);
});

var add8 = edge.func('Sample105.dll');
add8(4, function (error, result) {
	if (error) throw error;
	console.log("add8", result);
});

add8(5, function (error, result) {
	if (error) throw error;
	console.log("add8", result);
});

add7(2, function (error, result) {
	if (error) throw error;
	console.log("add7", result);
});

add7(3, function (error, result) {
	if (error) throw error;
	console.log("add7", result);
});

