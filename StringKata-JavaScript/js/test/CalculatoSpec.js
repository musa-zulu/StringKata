///<reference path="/Scripts/jasmine.js"/>
///<reference path="/js/Calculator.js"/>

describe("String Calculator", function () {
    describe("Add(input)", function () {
       
        it("Should return zero given empty input", function () {
            var input = "";
            var number = 0;
            var calculator = new Calculator();
            var results = calculator.add(input);

            expect(results).toEqual(number);
        });

        it("Should return single number given single number input", function () {

            var input = "1";
            var number = 1;
            var calculator = createCalculator();
            var results = calculator.add(input);
            expect(results).toEqual(number);
        });

        it("Should return a large single number given a large single number input", function () {
            var input = "450";
            var number = 450;
            var calculator = createCalculator();
            var results = calculator.add(input);
            expect(results).toEqual(number);
        });

        it("Should return a sum given two numbers separated by a comma delimiter", function () {
            var input = "1,2";
            var number = 3;
            var calculator = createCalculator();
            var results = calculator.add(input);
            expect(results).toEqual(number);
        });

        it("Should return a sum given many numbers with a comma delimiter", function () {
            var input = "1,2,3,4,5";
        });

        var createCalculator = function() {
             return new Calculator();
        };
    });
});

