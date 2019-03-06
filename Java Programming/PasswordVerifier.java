import java.io.*;

public class PasswordVerifier {
    public static void main(String [] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        String userInput  = br.readLine();
        int upperCase = 2, lowerCase = 2, numbers = 2, specialChars = 2;
        for(int i = 0, max = userInput.length() ; i < max ; i++) {
            char ch = userInput.charAt(i);
            if(ch >= 'A' && ch <= 'Z') {
                upperCase--;
            } else if(ch >= 'a' && ch <= 'z') {
                lowerCase--;
            } else if(ch >= '0' && ch <= '9') {
                numbers--;
            } else {
                specialChars--;
            }
        }

        if(upperCase > 0 || lowerCase > 0 || numbers > 0 || specialChars > 0) {
            System.out.print("Invalid");
        } else {
            System.out.print("Valid");
        }
    }
}