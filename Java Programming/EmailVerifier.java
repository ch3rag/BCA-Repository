import java.io.*;
public class EmailVerifier {
    public static void main(String [] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        String input = br.readLine().toLowerCase();
        boolean flag = true;
        boolean beforeDomain = true;
        int domainLength = 0;
        int subDomainCount = 0;
        for(int i = 0, max = input.length() ; i < max ; i++) {
            char ch = input.charAt(i);
            if(i == 0) {
                if(!(ch >= 'a' && ch <= 'z')) {
                    flag = false;
                    break;
                }
            } else if(beforeDomain) {
                if(ch == '@') beforeDomain = false;
                else if(!((ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9') || ch == '.' || ch == '_')) {
                    flag = false;
                    break;
                }
            } else {
                if(!((ch >= 'a' && ch <= 'z') || ch == '.')) {
                    flag = false;
                    break;
                }

                if(ch == '.' && domainLength == 0) {
                    flag = false;
                    break;
                }

                if(ch != '.') {
                    domainLength++;
                } else {
                    subDomainCount++;
                    domainLength = 0;
                }

                if(subDomainCount > 2) {
                    flag = false;
                    break;
                }
            }
        }
        if(subDomainCount == 0 || beforeDomain) {
            flag = false;
        }
        System.out.println(flag);
    }
}