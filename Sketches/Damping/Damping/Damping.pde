float x1, x2, x3;
float v2;

void setup()
{
  size (500, 500, P2D);
}

void draw()
{
  background(0);
  
  if(x1 < mouseX) 
  {
    x1 += 5;
    if (x1 > mouseX) x1 = mouseX;
  }
  else 
  {
    x1 -= 5;
    if (x1 < mouseX) x1 = mouseX;
  }
  
  if(x2 < mouseX) v2++;
  else v2--;  
  v2 *= .95;  
  x2 += v2;
  
  x3 = lerp(x3, mouseX, .1);  
  
  ellipse(x1, height*1/4, 25, 25);
  ellipse(x2, height*2/4, 25, 25);
  ellipse(x3, height*3/4, 25, 25);
}
