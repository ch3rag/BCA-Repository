GitHub Notes

About Bash
> Bash is a Unix shell and command language written by Brian Fox for the GNU Project.

Three states of file in GitHub
1. Modified
2. Staged
3. Commmit

*** Commands ***

--Configuring the user name
git config --global user.name "Chirag Singh"

--Configuring the email
git -config --global user.email chiragxyz@xyz.Commmit

--Changing directories
cd "My Documents"
cd ..

--Displaying configuration
git config --list

--Git help
git help

--Getting help on specific command
git help command_name

--Clearing bash
clear

--Listing files in directory
ls

--Listing files in directory (include hidden)
ls -a

--Initializing a directory as repository
git init

--Tracking file(s) in a directory
git add filename
git add *
git add *.extension

--Display status of files
git status

--Display changes since last commit
git diff

--Display what has been staged but not yet committed
git diff --cached

--Committing file(s)
git commit

This opens up editor consisting:
> Commit Title
> Commit Description
> List of changes preceded by *
> Closes-Bug: #Bug_Number (Bug Removed list)

ESC and :wq to confirm and commit


--To skip opening commit message editor
git commit -m 'Message'

--To skip staging as well as commit message editing
git commit -a -m 'Message'

--To remove file(s)
git rm filename

If file is in staging state
git rm -f filename

--Remove a file from staging state
git rm --cached filename

--Renaming a file
git mv old_name new_name

--View all of the commits
git log

To Format log

> %h      HASH
> %an     NAME OF AUTHOR(UNIX TIMESTAMP)
> %ar     TIME OF COMMIT(RELATIVE)
> %at     AUTHOR DATE
> %s      FIRST LINE OFF COMMIT MESSAGE
> %cn     NAME OF COMMITTER
> %ct     COMMIT DATE(UNIX TIMESTAMP)

git log --pretty=oneline
git log --pretty=format:"%h : %an : %ar : %s"

--View last few commits
git log -p -1
git log -p -2

--View abbreviated stat
git log --stat

--View log since/before
git log --since=1.week
git log --since="YYYY-DD-MM"
git log --before="YYYY-DD-MM"

--View log of specific author
git log --author="Chirag Singh"

--Undo commits
git commit --amend

--Unstage a file
git reset HEAD filename
