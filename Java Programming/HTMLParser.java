class HTMLParser {
    public static void main(String [] args) {
        String tags = "";
        int numTags = 0;
        boolean inTag = false;
        String testHTML = "<HTML><HEAD><TITLE>Your Title Here</TITLE><BODY BGCOLOR=\"FFFFFF\"><CENTER><IMG SRC=\"clouds.jpg\" ALIGN=\"BOTTOM\"> </CENTER><HR><a href=\"http://somegreatsite.com\">Link Name</a>is a link to another nifty site<H1>This is a Header</H1><H2>This is a Medium Header</H2>Send me mail at <a href=\"mailto:support@yourcompany.com\">support@yourcompany.com</a>.<P> This is a new paragraph!<P> <B>This is a new paragraph!</B><BR> <B><I>This is a new sentence without a paragraph break, in bold italics.</I></B><HR></BODY></HTML>";
        testHTML = testHTML.toLowerCase();
        // EXTRACT ALL TAGS
        String word = "";
        for(int i = 0, max = testHTML.length(); i < max ; i++) {
            char ch = testHTML.charAt(i);
            if(ch == '<') {
                inTag = true;
                continue;
            } else if(ch == '>') {
                inTag = false;
                if( word.equals("area") || word.equals("base") || word.equals("br") || word.equals("col") || 
                word.equals("command") || word.equals("embed") || word.equals("hr") || word.equals("img") || 
                word.equals("input") || word.equals("keygen") || word.equals("link") || word.equals("meta") || 
                word.equals("param") || word.equals("source") || word.equals("track") || word.equals("wbr")) {
                    word = "";
                    continue;
                } else {
                    tags += word + " ";
                    word = "";
                    numTags++;
                }

            }
            if(inTag) {
                if(ch == '/') continue;
                if(ch == ' ') 
                    inTag = false;
                else
                    word = word + ch;
            }
        }
        word = "";
        int index = 0;
        String[] tagAr = new String[numTags];
        for(int i = 0, max = tags.length() ; i < max ; i++) {
            char ch = tags.charAt(i);
            if(ch != ' ') {
                word = word + ch;
            } else {
                tagAr[index++] = word.trim();
                word = "";
            }
        }

        for(int i = 0 ; i < tagAr.length ; i++) {
            for(int j = i ; j < tagAr.length ; j++) {
                if(tagAr[i].compareTo(tagAr[j]) > 0) {
                    String temp = tagAr[i];
                    tagAr[i] = tagAr[j];
                    tagAr[j] = temp;
                }
            }
        }

        for(int i = 0 ; i < tagAr.length ; i++) {
            if(tagAr[i].equals(tagAr[i+1])) i++;
            else System.out.println(tagAr[i] + ": Missing Matching Tag!");
        }
    }
}