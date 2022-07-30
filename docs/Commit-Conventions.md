
# Commit Conventions
We follow [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/) to write the commit messages.
The commit message should be structured as follows:

```
<type>: <subject>
empty separator line
<optional body>
empty separator line
<optional footer>

```

# Type
Type Must be one of the following:

- feat: A new feature
- fix: A bug fix
- refactor: A change that refactor the current code
- style: Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc.)
- test: Adding missing tests or correcting existing tests
- docs: Documentation only changes
- chore: a catch-all type for any other commits. For instance, if you're implementing a single feature and it makes sense to divide the work into multiple commits, you should mark one commit as feat and the rest as chore.

## Subject
The subject contains a succinct description of the change.

- Is a mandatory part of the format
- Use the imperative, present tense: "change" not "changed" nor "changes"
- Don't capitalize the first letter
- No dot (.) at the end

## Body
The body should include the motivation for the change and contrast this with previous behavior.

- Is an optional part of the format
- Use the imperative, present tense: "change" not "changed" nor "changes"

## Footer
The footer is the place to reference Issues that this commit refers to.

- Is an optional part of the format
- optionally reference an issue by its id.

## Examples

```
feat: display cards of the same type next to each other

This feature change the card's sorting behavior to diplay cards of the same type next to each other. 

refers to [issue#15](https://github.com/hamed-shirbandi/TaskoMask/issues/15)

```

```
style: remove empty line

```

```
fix: add missing parameter to service call

The error occurred because of <reasons>.

```