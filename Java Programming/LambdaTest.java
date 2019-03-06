import java.util.*;

public class LambdaTest {
    public static void main(String [] args) {

        // Sum Of Squares of All Even Numbers in the array
        int [] arr = {1, 2, 3, 4, 5, 6, 7};
        int result = Arrays.stream(arr).filter(x -> x%2==0).map(x -> x*2).reduce(10, (x, c) -> x + c);
        System.out.println(result);

        // Extracting Initials
        String sentence = "Chirag Singh Rajput Lucknow";
        String initials = Arrays.stream(sentence.split(" ")).map(x -> "" + x.charAt(0)).reduce("", (x, c) -> x + c);
        System.out.println(initials);


        // Reverse Each Word
        String reverse = Arrays.stream(sentence.split(" ")).map(x -> new StringBuilder(x).reverse().toString()).reduce("", (x, c) -> x + c + " ");
        System.out.println(reverse);

        // Remove All Non-Palindrome Words
        String palindromeTest = "ada madam chirag oppo singh xyz klommolk";
        String filtered = Arrays.stream(palindromeTest.split(" ")).filter(x -> x.equals(new StringBuilder(x).reverse().toString())).reduce("", (x, c) -> x + c + " ");
        System.out.println(filtered);

        // Find Largest Word
        String largest = Arrays.stream(sentence.split(" ")).reduce("", (x, c) -> x = x.length() < c.length()? c : x);
        System.out.println(largest);
    }
}