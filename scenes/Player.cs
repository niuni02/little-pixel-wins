using Godot;

public partial class Player : CharacterBody2D
{
	[Export]
	public float Speed = 100.0f;

	private AnimatedSprite2D animatedSprite;
	private Vector2 facingDirection = Vector2.Down;

	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		PlayIdleAnimation();
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction = Input.GetVector(
			"move_left",
			"move_right",
			"move_up",
            "move_down"
		);

		// Prevent diagonal movement (Pokémon style)
		if (direction.X != 0)
		{
			direction.Y = 0;
		}

		if (direction != Vector2.Zero)
		{
			facingDirection = direction;
			Velocity = direction * Speed;

			PlayWalkAnimation();
		}
		else
		{
			Velocity = Vector2.Zero;

			PlayIdleAnimation();
		}

		MoveAndSlide();
	}

	private void PlayWalkAnimation()
	{
		if (facingDirection == Vector2.Down)
		{
			animatedSprite.Play("down_walk");
		}
		else if (facingDirection == Vector2.Up)
		{
			animatedSprite.Play("up_walk");
		}
		else if (facingDirection == Vector2.Left)
		{
			animatedSprite.Play("left_walk");
		}
		else if (facingDirection == Vector2.Right)
		{
			animatedSprite.Play("right_walk");
		}
	}

	private void PlayIdleAnimation()
	{
		if (facingDirection == Vector2.Down)
		{
			animatedSprite.Play("down_idle");
		}
		else if (facingDirection == Vector2.Up)
		{
			animatedSprite.Play("up_idle");
		}
		else if (facingDirection == Vector2.Left)
		{
			animatedSprite.Play("left_idle");
		}
		else if (facingDirection == Vector2.Right)
		{
			animatedSprite.Play("right_idle");
		}
	}
}
