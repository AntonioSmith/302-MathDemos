void setup()
{
  size(500, 500);
}

void draw()
{
  background(128);
  
  float p = mouseX / (float)width;
  float radians = map(mouseX, 0, width, 0, 3);
  
  pushMatrix();
  translate(width/2, height/2);
  //rotate(a);  
  rect(-200, -200, 400, 400);
  popMatrix();
}
