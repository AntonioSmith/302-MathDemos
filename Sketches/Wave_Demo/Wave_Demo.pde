

void setup()
{
  size(800, 500);
  stroke(150, 0, 250);
}

void draw()
{
  background(64); 
  
  float time = millis()/1000.0;
  
  // -1 to 1 (range of 2)
  // 2 to 20 (range of 18)
  float t = sin(time * 2) * 9 + 11; // Adding 11 fixes the equation to never be negative causing it to crash.
  strokeWeight(t);
  
  ellipse(width/2, height/2, 400, 400);
}
