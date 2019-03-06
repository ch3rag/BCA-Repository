import java.util.regex.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.stream.Collectors;
class HTMLParserRegex {
    public static void main(String [] args) {
        ArrayList <String> tags = new ArrayList <String> ();
        ArrayList <String> notClosedTags = new ArrayList <String> ();
        String[] voidTags = {"area", "base", "br", "col", "command", "embed", "hr", "img", "input", "keygen", "link", "meta", "param", "source", "track", "wbr"};
        ArrayList <String> voidTagsList = new ArrayList(Arrays.asList(voidTags));  
        String testHTML = "<HTML><HEAD><TITLE>Your Title Here</TITLE><BODY BGCOLOR=\"FFFFFF\"><CENTER><IMG SRC=\"clouds.jpg\" ALIGN=\"BOTTOM\"> </CENTER><HR><a href=\"http://somegreatsite.com\">Link Name</a>is a link to another nifty site<H1>This is a Header</H1><H2>This is a Medium Header</H2>Send me mail at <a href=\"mailto:support@yourcompany.com\">support@yourcompany.com</a>.<P> This is a new paragraph!<P> <B>This is a new paragraph!</B><BR> <B><I>This is a new sentence without a paragraph break, in bold italics.</I></B><HR></BODY></HTML>";
        testHTML = testHTML.toLowerCase();
        Matcher captureTags = Pattern.compile("<\\/?([a-zA-Z0-9]+)(\\s.*?)*?>").matcher(testHTML);
        while(captureTags.find()) tags.add(captureTags.group(1));
        tags = tags.stream().filter(x -> !voidTagsList.contains(x)).collect(Collectors.toCollection(ArrayList::new));
        Collections.sort(tags);
        for(int i = 0, max = tags.size() - 1 ; i < max ; i++) {
            if(tags.get(i).equals(tags.get(i+1))) i++;
            else notClosedTags.add(tags.get(i));
        }
        notClosedTags.stream().forEach(HTMLParserRegex::printStats);
    }    
    static void printStats(String s) {
        System.out.println(s.toUpperCase() + " is not closed!");
    } 
}