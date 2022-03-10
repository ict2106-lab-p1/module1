# Development Workflow Guide

This document describes the workflow, conventions and best practices to follow with regards to Git.

## Default Branches
#### `mod2`   
This is the `main/master` branch for this repository. It is named like this to avoid confusion when integrating with other modules into the main repository. Do not commit directly to this branch. Branch protection rules have been setup to prevent this from happening. Only PRs from `dev` should be merged into this branch. 

#### `dev`  
This is the default branch for all development work. Completed features will be merged here first. Commits to this branch should be made via PRs as well. 

## Creating a new Feature branch
All new features should be created as a new branch. Feature branches should branch off `dev` first.

The name of the branch should follow this pattern:
- `<group number>-<issue number>-<feature name>`  
- group number just need to be prefixed with a `g` followed by your group number
- all feature branches MUST have an issue created in your Github Project Board
- all text should be lowercase and separated by dashes `-`

#### Example of feature branch creation: 
`git checkout -b g1-50-file-processing dev`

## Committing
After you are done writing your code:
- Stage all your changes with `git add .`
- Double check that you have staged the correct files with `git status`
- Write a commit message with `git commit -m "message"`
  - start with a `#<issue number>` to associate your commit with an issue in your Github Project Board
  - add a `fix:` to a commit message if you are fixing an issue
  - add a `feat:` to a commit message if you are featuring a new feature
- Push your commit to the repo with `git push` or `git push -u origin <branch name` if Github have not tracked your branch
- Encouraged to perform small commits regularly 

When committing, it is a good practice to review every line of code that you commit. Craft your commit such that each commit only contains one change. This allows you to easily review the commit history and identify the cause of a bug.

#### Example of a commit:
```
git add .
git commit -m "git commit -m "#50 fix: null check before accessing file object"
git push
```

[Refer to: Git Commit Conventions](https://www.freecodecamp.org/news/writing-good-commit-messages-a-practical-guide/)

## Merging to `dev`
Once you are done with your feature:
- get the latest changes from `dev` by doing `git pull origin dev`
- fix any conflicts (if any) and test if the program still works
- push the changes to your feature branch with `git push`
- create a PR and set `base: dev` and `compare: <feature branch>`
- set a reviewer (that is not yourself) to review the PR
- delete your feature branch locally with `git branch -d <feature branch>`
- delete your feature branch on Github with `git push origin --delete <feature branch>`





