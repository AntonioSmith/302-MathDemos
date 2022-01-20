// Animate 3 electrons orbiting around a nucleus.
// Each electron should follow a path and match
// colors with its respective path.

// Don't use rotate()
// Use vectors and trigonometry

float x1, x2, x3;
float y1, y2, y3;

void setup(){
  size(400, 400);
}
void draw(){
  
  drawBackground();
  
  ///////////////// START YOUR CODE HERE:
  
  noStroke();
  fill(255);
  
  PVector red = FindOvalPos(0, 0);
  PVector green = FindOvalPos(60, 0);
  PVector blue = FindOvalPos(-60, 0);
    
  ellipse(red.x, red.y, 20, 20);
  ellipse(green.x, green.y, 20, 20);
  ellipse(blue.x, blue.y, 20, 20);
  
  ///////////////// END YOUR CODE HERE
  
}

PVector FindOvalPos(float rotateAmount, float timeOffset)
{
  float time = millis()/1000.0;
  
  // Find path on oval
  float x = cos(time);
  float y = sin(time);
  
  // Convert coorinates to polar
  float angle = atan2(y, x);
  float mag = sqrt(x*x + y*y);
  
  // rotate vector
  angle -= radians(60);
  
  // revert back to cartestian
  x = mag * cos(angle);
  y = mag * sin(angle);
  
  // translate to center of screen
  x += width/2;
  y += height/2;  
}

void drawBackground(){
  background(0);
  noStroke();
  fill(255);
  ellipse(200,200,50,50);
  noFill();
  strokeWeight(5);
  
  pushMatrix();
  translate(200,200);
  stroke(255,100,100);
  ellipse(0,0,300,100);
  popMatrix();
  
  pushMatrix();
  translate(200,200);
  rotate(PI/1.5);
  stroke(100,255,100);
  ellipse(0,0,300,100);
  popMatrix();
  
  pushMatrix();
  translate(200,200);
  rotate(2*PI/1.5);
  stroke(100,100,255);
  ellipse(0,0,300,100);
  popMatrix();
}
