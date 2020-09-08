# Linu  And Shell Scripting
 
## Unit 1
---
* [x] Operating System
* [x] Minimun Requirements 
* [x] Structure Of Unix
  * [x] Unix Kerel
  * [x] The Shell
    * [x] What Is Shell
    * [x] The Bourne Shell
    * [x] The C Shell
    * [x] The Korn Shell
* [ ] Unix File System
  * [x] Hierarchy
  * [x] bin Directory
  * [x] etc Directory
  * [x] lib Directory
  * [x] dev Directory
  * [x] usr Directory
  * [x] tmp Directory
* [ ] Files In Linux
  * [x] Introduction
  * [x] Linux File System
  * [x] boot Block
  * [x] super Block
  * [x] inode List
  * [x] data Block	
* [ ] Structure Of inode
  * [x] File Owner
  * [x] File Type
  * [x] Access Permissions
  * [x] Access Time
  * [x] Number Of Links To The File
  * [x] File Size
  * [x] Disk Block Addresses
* [x] File Permission
  * [x] Introduction
  * [x] Types Of Users
    * [x] Owner
    * [x] Group
    * [x] Public
  * [x] Types Of Permissions
  * [x] Changing File Permissions Using *chmod*
    * [x] Introduction
    * [x] Octal Mode
    * [x] Symbolic Mode

## Commands
* [ ] ls
  * [X] Introduction
  * [x] Options [ -a, -l, -S, -t, -r, -R, -d, -F, -X ]
  * [x] Outputs
* [x] whoami
* [x] who am i
* [x] who
* [x] logname
* [x] finger
* [x] pwd
* [x] cat
  * [x] Introduction
  * [x] Joining Files Together
  * [X] Default Behavior
  * [X] Creating Files
* [x] cd
* [x] cp
  * [x] Introduction & Usage
  * [x] Options [ -a, -i, -r, -u, -v ]
  * [x] Examples
* [x] rm
  * [x] Introduction & Usage
  * [x] Options [ -i, -r, -f, -v ]
  * [x] Examples
* [x] rmdir
* [x] mkdir
* [x] mv
  * [x] Introduction & Usage
  * [x] Options [ -i, -u, -v ]
  * [x] Examples
* [x] chmod
* [x] more
  * [x] Options [ -f, -d, +num]
* [x] less
  * [x] Keys [ PgUp/b, PgDn/Space, Up Arrow, Down Arrow, g, G, n, /chars, q, h ]
* [x] df [ Free Disk ]
* [x] free [ Free Ram ]

## Unit - 2
* [x] Standard Files
* [x] IO Redirection
  * [x] Introduction
  * [x] Redirecting Std Input
  * [x] Redirecting Std Output
  * [x] Redirecting Diagnostic Output
  * [x] Redirecting Both Std Output & Diagnostic Output
* [x] File Discriptors
* [x] Pipelines
  * [x] What Is Pipelining
  * [x] Filters
    * [x] sort
    * [x] uniq
    * [x] wc
    * [x] grep
    * [x] head
    * [x] tail
    * [x] tee
* [x] Background Processing
  * [x] Multitasking & Process
  * [x] How Process Works
  * [x] ps
  * [x] Starting Background Process
  * [x] kill	
    *  [x] Signal [1, 2, 9, 15, 19, 20]
  * [x] killall
  * [x] bg
  * [x] fg
  * [x] jobs
  * [x] top
  * [X] nice
  * [X] renice
* [x] bc
* [x] expr
* [x] factor
## Text Processing Commands
* [x] wc
  * [x] Options [ -l, -w, -c ]
* [x] tee
* [x] head
* [x] tail
* [ ] sort
  * [x] Introduction
  * [x] Options [ -b, -f, -n, -r, -k n[,n], -m, -o, -t ]
  * [x] Examples
* [x] uniq
  * [x] Introduction
  * [x] Options [ -c, -d, -u, -i, -f n, -s n ]
  * [x] Examples
* [x] vi Editor
  * [x] What Is Vi
  * [x] Modes In Vi
    * [x] Command Mode [ Default ]
    * [x] Insert Mode
  * [x] Starting Vi Editior [Normal, ReadOnly]
  * [x] Saving The File [:w, :w fileName]
  * [x] Exiting The Vi [ :q, :q!, :wq, ZZ ]
  * [x] Moving Cursor [ h, l, k, j, prefixing ]
  * [x] Moving Aroud Document [ 0, $, w, b, SHIFT+G, 1G, nG ] 
  * [x] Deleting Text [x, X, D, dd] 
  * [x] Searching [/search, /^search, /search$]
  * [x] Replacing [:s/match/replace, :%s/match/replace]
* [x] cmp
  * [x] Options [-b, -l, -i n:n]
* [x] comm
  * [x] Options [ -n, -nn ]
* [x] diff
  * [x] what is diff
  * [x] normal output
    * [x] Change Commands
      * [x] r1ar2
      * [x] r1cr2
      * [x] r1dr2
  * [x] context output
  * [x] unified output
* [x] sdiff
  * [x] Options [ -s, -l ]
* [x] patch 
* [x] cut
  * [x] option [ -c r1-r2[,r3-r4], -f n,[m], -d 'char', --complement ]
* [x] paste
* [x] join
* [x] tr
  * [x] what is tr
  * [x] Options [ -d, -s ]
* [x] sed
  * [x] what is sed command
  * [x] s command
  * [x] p command
  * [x] d command
  * [x] = command
  * [X] i command
  * [x] a command
  * [x] y command
  * [x] Addresses [ n, n,m, $, /regexp/, n~m, addr,+n, addr!]
* [x] grep & Regex
  * [x] what is grep
  * [x] grep options [ -l, -L, -h, -i, -v ]
  * [x] Literals
  * [x] Metacharactars
    * [x] Match Any Character [.]
    * [x] Achors [^, $] 
    * [x] Bracket Expressions & Negiation [ [chars], [^chars] ]
    * [x] Posix Character Classes
      * [x] [[:upper:]] 
      * [x] [[:lower:]]
      * [x] [[:alpha:]]
      * [x] [[:alphanum:]]
      * [x] [[:space:]]
      * [x] [[:digit:]]
      * [X] [[:blank:]]
    * [x] Quantifiers
      * [x] ?
      * [x] *
      * [x] +
      * [x] { }
* [ ] pr
* [x] egrep
* [ ] awk
  * [ ] What Is Awk
  * [ ] Any 5 Funtions
  * [ ] 10 Programs
 
 ## Unit - 3
* [x] id Command
* [x] Effect Of Permissions On Files And Directories
* [x] chmod
* [x] chown
* [x] chgrp
* [x] passwd [user]
* [x] su [options] [username]
  * [x] options [ -l, -c ]
* [x] sudo -username
* [x] useradd
  * [x] Options
    * [x] -m [Create Home Directory]
    * [x] -d directory [Specify The Location Of The Home Directory]
    * [x] -u [Specify The UserId]
    * [x] -g [Specify The Group Or Gid]
    * [x] -G [Specify One Or More Secondary Groups]
    * [x] -e [Set Password Expiration Date YYYY-MM-DD]
  * [x] userdel
    * [x] Options
      * [x] -r [Remove Home Directory]
      * [x] -f [Forcefully]