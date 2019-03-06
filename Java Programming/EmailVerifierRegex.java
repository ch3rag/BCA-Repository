import java.io.*;
import java.util.regex.Pattern;

public class EmailVerifierRegex {
    public static void main(String [] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        String userInput  = br.readLine();
        if(Pattern.matches("[A-Za-z][A-Za-z0-9_\\.]*?@[a-zA-Z]+(\\.[a-zA-Z]+){1,2}", userInput)) {
            System.out.println("Valid");
        } else {
            System.out.println("Invalid");
        }

    }
}