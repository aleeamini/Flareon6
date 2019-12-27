from PIL import Image
bmp=Image.open("output.bmp")
s=""
ofile=open("extdata2","w+b")
pixels=bmp.load()
for x in range(0,bmp.width):
    s=""
    for y in range(0,bmp.height):
        r,g,b=pixels[x,y]
        s += format(b, '08b')[-2:]
        s += format(g, '08b')[-3:]
        s += format(r, '08b')[-3:]
        byte=int(s,2)
        ofile.write("%c" % byte)
        s=''
ofile.close()