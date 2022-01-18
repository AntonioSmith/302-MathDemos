// Animate 3 electrons orbiting around a nucleus.
// Each electron should follow a path and match
// colors with its respective path.

// Don't use rotate()
// Use vectors and trigonometry

float x1 = 350;
float x2 = 200;
float x3 = 200;
float y1 = 200;
float y2 = 200;
float y3 = 200;

void setup(){
  size(400, 400);
}
void draw(){
  
  drawBackground();
  
  ///////////////// START YOUR CODE HERE:
  
  // Move Red Electron
  if(x1 > 200) x1 -= 3;
  if(y1 < 250) y1 += 2;
  
  // Draw Red Electron
  noStroke();
  fill(255,100,100);  
  ellipse(x1, y1, 30, 30);
  
  // Draw Green Electorn
  noStroke();
  fill(100,255,100);  
  ellipse(x2, y2, 30, 30);
  
  // Draw Blue Electron
  noStroke();
  fill(100,100,255);  
  ellipse(x3, y3, 30, 30);
  
  ///////////////// END YOUR CODE HERE
  
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
