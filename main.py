import pygame

pygame.init()
# display screen
screen = pygame.display.set_mode((1200, 800))
pygame.display.set_caption('World after Death')
screen.fill('lightskyblue3')

# row of input
input_box = pygame.draw.rect(screen, 'black', (0, 760, 1200, 40))
user_text = ''
base_font = pygame.font.Font(None, 32)

# fake characters
char_1 = pygame.draw.rect(screen, 'red', (600, 300, 60, 60))
char_2 = pygame.draw.rect(screen, 'blue', (900, 300, 60, 60))

# tool bar
tool_bar = pygame.draw.rect(screen, 'white', (150, 650, 900, 70))

# create function for skills
def Attack():
    pass

def Heal():
    pass

# get user command
def InputBox(event):
    global user_text
    if event.type == pygame.KEYDOWN:
  
        # Check for backspace
        if event.key == pygame.K_BACKSPACE:
  
            # get text input from 0 to -1 i.e. end.
            user_text = user_text[:-1]
  
        # Unicode standard is used for string
        # formation
        else:
            user_text += event.unicode

        if event.key == pygame.K_RETURN:
            user_input = user_text
            user_text = ''
            return user_input

        pygame.draw.rect(screen, 'black', input_box)
  
        text_surface = base_font.render(user_text, True, (255, 255, 255))

        # render at position stated in arguments
        screen.blit(text_surface, (input_box.x + 5, input_box.y + 5))

        # set width of textfield so that text cannot get
        # outside of user's text input
        input_box.w = max(100, text_surface.get_width() + 10)
    
# process user input 
def Processor(user_text):
    if user_text[0] == '/':
        user_text = user_text.replace(user_text[0], '')
        user_text = user_text.split()
        if user_text[0] == 'use':
            print('using item')
        elif user_text[0] == 'ew':
            print('weapond equiped')
        else:
            print('skill equiped')

# generate skills, player status
skill = [Attack, Heal]
player_input_skill = ''
player_class = ''
heath = 0
energy = 0

# main fuction
close = True
while close:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
                close = False
  
        user_input = InputBox(event)
        if user_input != None:
            Processor(user_input)   

    pygame.display.update()
