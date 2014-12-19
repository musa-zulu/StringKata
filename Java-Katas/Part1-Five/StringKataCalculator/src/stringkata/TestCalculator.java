package stringkata;

import static org.junit.Assert.*;

import org.junit.Ignore;
import org.junit.Test;

public class TestCalculator {

	@Test
	public void given_emptyInputString_shouldReturnZero() {

		String input = "";
		int expected = 0;

		Calculator calc = new Calculator();

		int results = calc.add(input);

		assertEquals(expected, results);
	}

	@Test
	public void given_InputStringWithSingleNumber_shouldReturnNumber() {

		String input = "1";
		int expected = 1;

		Calculator calc = new Calculator();
		int results = calc.add(input);
		assertEquals(expected, results);
	}

	@Test
	public void given_InputStringWithTwoNumbers_shouldReturnSum() {

		String input = "1,2";
		int expected = 3;

		Calculator calc = new Calculator();
		int results = calc.add(input);
		assertEquals(expected, results);
	}

	@Test
	public void given_InputStringWithManyNumbers_shouldReturnSum() {

		String input = "1,2,3,4,5";
		int expected = 15;

		Calculator calc = new Calculator();
		int results = calc.add(input);
		assertEquals(expected, results);
	}

	@Test
	public void given_InputStringWithNewLineInBetweenNumbers_shouldReturnSum() {

		String input = "1\n2";
		int expected = 3;

		Calculator calc = new Calculator();
		int results = calc.add(input);
		assertEquals(expected, results);
	}
	

	@Test
	public void given_InputStringWithDelimiterInBetweenNumbers_shouldReturnSum() {

		String input = "//;\n1;3";
		int expected = 4;

		Calculator calc = new Calculator();
		int results = calc.add(input);
		assertEquals(expected, results);
	}
}
