import java.util.ArrayList;
import java.util.Collections;
import java.util.Arrays;

public class HTMLParserExtended {
    public static void main(String [] args) {
        String testHTML =   "<HTML>\n"
                            +   "<HEAD>\n"
                            +       "<TITLE>Your Title Here</TITLE>\n"
                            //+   "</HEAD>\n"
                            //+   "<BODY BGCOLOR=\"FFFFFF\">\n"
                            +       "<CENTER><IMG SRC=\"clouds.jpg\" ALIGN=\"BOTTOM\"></CENTER>\n"
                            +       "<HR>\n"
                            +       "<a href=\"http://somegreatsite.com\">Link Name</a>is a link to another nifty site\n"
                            +       "<H1>This is a Header</H1>\n"
                            +       "<H2>This is a Medium Header</H2>\n"
                            +       "Send me mail at <a href=\"mailto:support@yourcompany.com\">support@yourcompany.com\n" //</a>.\n"
                            +       "<P> This is a new paragraph!<P>\n"
                            +       "<B>This is a new paragraph!</B>\n"
                            +       "<BR>\n"
                            +       "<B><I>This is a new sentence without a paragraph break, in bold italics.</I></B>\n"
                            +       "<HR>\n"
                            +   "</BODY>\n"
                            +"</HTML>\n"
                            +"<H1>Hey";
    
        HTMLParser parser = new HTMLParser(testHTML);
        parser.parse();
        parser.printStats();
    }
}


class HTMLParser {
    private ArrayList <Tag> tags;
    private String document;
    HTMLParser(String document) {
        tags = new ArrayList <Tag>();
        this.document = document.toLowerCase();;
    }

    public void parse() {
        int lineCount = 1;
        int column = 1;
        String tag = "";
        Tag tagObj = null;
        boolean inTag = false;
        for(int i = 0, max = document.length() ; i < max ; i++) {
            char ch = document.charAt(i);
            if(ch == '\n') {
                lineCount++;
                column = 1;
            } else {
                column++;
            }
            if(ch == '<') {
                inTag = true;
                // NEW TAG
                tagObj = new Tag();
                tagObj.setLine(lineCount);
                tagObj.setIndex(column - 1);
                
            } else if(ch == '>') {
                inTag = false;
                tagObj.setName(tag);
                tag = "";
                tags.add(tagObj);
            } else if(inTag) {
                if(ch == '/') {
                    // SET TAG AS CLOSING TAG
                    tagObj.setClosed(true);
                } else if(ch == ' ') {
                    inTag = false;
                } else {
                    tag = tag + ch;
                }
            }
        }
    }

    public void printStats() {
        Collections.sort(tags, (t1, t2) -> t1.getName().compareTo(t2.getName()));
        String[] voidTags = {"area", "base", "br", "col", "command", "embed", "hr", "img", "input", "keygen", "link", "meta", "param", "source", "track", "wbr"};
        ArrayList <String> voidTagsList = new ArrayList(Arrays.asList(voidTags)); 
        for(int i = 0, max = tags.size() ; i < max ; i++) {
            Tag curTag = tags.get(i);
            Tag nextTag = null;
            if(i < max - 1) nextTag = tags.get(i + 1);
            if (voidTagsList.contains(curTag.getName())) continue;
            if(nextTag == null) {
                System.out.println(curTag.getName().toUpperCase() + (curTag.getClosed()? " is not opened but closed." : " is opened but not closed.") + " At Line: " + curTag.getLine() + " Column: " + curTag.getIndex());
            } else if(curTag.getName().compareTo(nextTag.getName()) == 0) {
                i++;
            } else {
                System.out.println(curTag.getName().toUpperCase() + (curTag.getClosed()? " is not opened but closed." : " is opened but not closed.") + " At Line: " + curTag.getLine() + " Column: " + curTag.getIndex());
            }
        }
    }
}

class Tag {
    private String name;
    private boolean isClosed;
    private int line;
    private int index;

    Tag() {
        name = "";
        isClosed = false;
    }
    
    public void setName(String name) {
        this.name = name;
    }

    public void setClosed(boolean flag) {
        this.isClosed = flag;
    }

    public void setIndex(int i) {
        this.index = i;
    }

    public void setLine(int line) {
        this.line = line;
    }

    public String getName() {
        return name;
    } 

    public int getLine() {
        return line;
    }

    public int getIndex() {
        return index;
    }

    public boolean getClosed() {
        return isClosed;
    }
}