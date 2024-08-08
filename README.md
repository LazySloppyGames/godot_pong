This is a crude version of Pong using the built-in Godot font.
Left Player Keys: w for up, s for down
Right Player Keys: up arrow for up, down arrow for down

Known Issues:
Paddle position controlled by ball.
I believe this is a bug due to MoveAndSlide and MoveAndCollide. Touching the ball and the bottom of the paddle
will cause the ball to move the paddle, even teleporting it to the center of the screen if the touch is when a
goal is scored.

Solution:
Eliminate MoveAndSlide and MoveAndCollide and replace them with a function to control movement. Otherwise,
everything should work fine.
