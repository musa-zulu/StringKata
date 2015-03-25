var Calculator = function() {

    return {
        add: function (input) {

            if (input.length == 0) {
                return 0;
            }

            if (input.indexOf(",") > 0) {
                var numbers = input.split(',');
                return Number(numbers[0]) + Number(numbers[1]);
            }
            return Number(input);
        }
    }
}

