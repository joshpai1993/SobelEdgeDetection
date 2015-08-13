#Declaration 

![Alt text](/screenshot.png " " ) 


The operator uses two 3�3 kernels which are�convolved�with the original image to calculate approximations of thederivatives�- one for horizontal changes, and one for vertical. 

If we define�A�as the source image, and�Gx�and�Gy�are two images which at each point contain the horizontal and vertical derivative approximations, the computations are as follows: 

![Alt text](/formula.png " " )

where��here denotes the 2-dimensional�convolution�operation.



The�x-coordinate is defined here as increasing in the "right"-direction, and the�y-coordinate is defined as increasing in the "down"-direction. At each point in the image, the resulting gradient approximations can be combined to give the gradient magnitude, using:


![Alt text](/formulaG.png " " )


![Alt text](/code.png " " )


