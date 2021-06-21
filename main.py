import pygame

pygame.init()
# display screen
screen = pygame.display.set_mode((1200, 800))
pygame.display.set_caption('World after Death')
screen.fill('white')

# create function for skills
def Attack():
    pass

def Heal():
    pass

# generate skills, player status
skill = [Attack, Heal]
player_input_skill = ''
player_class = ''
heath = 0
energy = 0

pygame.display.update()