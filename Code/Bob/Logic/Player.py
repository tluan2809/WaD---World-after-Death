from Physics.Physics import *
import pygame
import sys 



class Player (pygame.sprite.Sprite() ,  Rectangle2D):

    def __init__(self , x , y ,size):
        Rectangle2D.__init__(self , size , x, y)
        self.velocity.x = 0 
        self.velocity.y = 0
        self.speed = 1 
    
    def Move(self, direction):
        if(direction == "left"):
            self.x -= self.velocity.x 
            return 0
        if(direction == "right"):
            self.x += self.velocity.x 
            return 0 
        if(direction =="up"):
            self.y -= self.velocity.y 
            return 0 
        if(direction =="down"):
            self.y += self.velocity.y 
            return 0 

    def Animation(self , Sprite_sheet , display ):
        for sprites in Sprite_sheet : 
            display.blit(sprites , (self.x , self.y))    
        return 0 
