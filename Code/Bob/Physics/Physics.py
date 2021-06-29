import pygame
import sys




def IsTouchingLeft( ):
    return True


def IsTouchingRight():
    return True

def IsTouchingTop():
    return True


def IsTouchingBottom():
    return True



class Rectangle2D :  #mọi object không phải windown sẽ kế  thừa class này
    
    def __init__(self , size , speed , x, y):  #same up
        self.size_x = size[0]
        self.size_y = size[1]
        self.Fallingspeed = speed
        self.x = x 
        self.y = y
    
    def Top_Left_position(self):
        return (self.x , self.y)
    
    def Bottom_Right_position(self) :
        return (self.x + self.size_x , self.y + self.size_y )  

    def CollisionDetective(self , Sprites):  #Lists chứa phần tử kế thừa Rectangle2D để nhận biết có va chạm xảy ra

        for i in Sprites :
            if(i == self):
                continue
        
            






