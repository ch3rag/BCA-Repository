import java.io.*;
public class EmailNew {
    public static void main(String [] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        String userInput  = br.readLine();
        boolean flag = true;
        boolean breforeAtTheRate = true;
        
        int domainLength = 0;
        int domainCount = 0;

        for(int i = 0, max = userInput.length() ; i < max ; i++) {
            char ch = userInput.charAt(i);
            if(i == 0) {
                if(!(ch >= 'a' && ch <= 'z')) {
                    flag = false;
                    break;
                }
            } else if(i > 0 && breforeAtTheRate) {
                if(ch == '@') {
                    breforeAtTheRate = false;
                    continue;
                }
                if(!((ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9') || ch == '.' || ch == '_')) {
                    flag = false;
                    break;
                }
            } else {
               
                //  CHECK FOR DOMAIN

                // CHECK A-Z OR DOT
                if((ch >= 'a' && ch <= 'z')) {
                    domainLength++;
                } else if(ch == '.') {
                    if(domainLength == 0 || domainCount == 2) {
                        flag = false;
                        break;
                    } else {
                        domainCount++;
                        domainLength = 0;
                    }
                } else { // CHARACTER IS NEITHER A-Z NOR .
                    flag = false;
                    break;
                }
            }
        }
        //  @ NOT PRESENT OR EMAIL IS LIKE xyz@abc OR xyz@abc.
        if(breforeAtTheRate || domainCount == 0 || domainLength == 0) flag = false;
        System.out.println(flag);
    }
}