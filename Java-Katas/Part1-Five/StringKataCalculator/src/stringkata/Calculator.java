package stringkata;

public class Calculator {

	public int add(String numbers) {
		if (isNullOrEmpty(numbers)) {
			return defaultValue();
		}
		String delimiters = ",\n";
		if (numbers.indexOf("//") != -1) {			
			int index = numbers.indexOf("\n");
			delimiters += numbers.substring(2, index);
			numbers = numbers.substring(index + 1, numbers.length());
		}
		String[] values = split(numbers, delimiters);
	System.out.println(values);
		return sumAll(values);
	}

	private String[] split(String numbers, String delimiters) {
		return numbers.split(delimiters);
	}

	private int sumAll(String[] values) {
		int sum = 0;
		for (String number : values) {
			sum += Integer.parseInt(number);
		}
		
		return sum;
	}

	private int defaultValue() {
		return 0;
	}

	private boolean isNullOrEmpty(String numbers) {
		return numbers.isEmpty();
	}
}
