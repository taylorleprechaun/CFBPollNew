# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS) !!!!!!!!!!!

### Recent changes

* Nothing recently but soon ™ 👀

### Rankings (Updated 1/10/2023)

**Week 17 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Georgia | 1.0000 | 15-0
2 | Michigan | 0.9105 | 13-1
3 | Tennessee | 0.9087 | 11-2
4 | Texas Christian | 0.8984 | 13-2
5 | Alabama | 0.8926 | 11-2
6 | Ohio State | 0.8898 | 11-2
7 | Penn State | 0.8757 | 11-2
8 | Oregon | 0.8538 | 10-3
9 | Tulane | 0.8498 | 12-2
10 | Clemson | 0.8473 | 11-3
11 | USC | 0.8409 | 11-3
12 | Washington | 0.8383 | 11-2
13 | Louisiana State | 0.8369 | 10-4
14 | Troy | 0.8352 | 12-2
15 | Kansas State | 0.8329 | 10-4
16 | Florida State | 0.8302 | 10-3
17 | Oregon State | 0.8299 | 10-3
18 | Mississippi State | 0.8168 | 9-4
19 | Utah | 0.8119 | 10-4
20 | UTSA | 0.7821 | 11-3
21 | UCLA | 0.7818 | 9-4
22 | Pittsburgh | 0.7764 | 9-4
23 | Notre Dame | 0.7730 | 9-4
24 | Texas | 0.7710 | 8-5
25 | Mississippi | 0.7669 | 8-5

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2022/2022-Week%2017%20NCG.md)

#### Observations and Notes (Updated 1/10/2023)

* 😢 Go Gators
* With another season in the books I want to thank anyone who's looked at this page for more 
than a couple minutes. At the start I didn't make this program with any purpose other than to see if I could and now it's something I spend a lot of time on and really am proud of. I have some big plans in store for it that I hopefully can get done. Sometimes being a software engineer for a living can suck the enjoyment out of personal projects like these but I've learned a lot in the last couple years that I'm excited to try out here.

#### Predictions (Updated 1/10/2023)

Week 16 Results (championship game) [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2022/Predictions/2022-Week%2016%20NCG.md):
* Winner: 1 - 0
* ATS: 0 - 1
* O/U: 0 - 1

Season Results:
* Winner: 485 - 240 (66.9%)
* ATS: 341 - 383 (47.1%)
* O/U: 372 - 352 (51.4%)

Retrospective:
* This was my first season running the predictions for every game (instead of a select few) and on the whole I'm happy with it. There are a number of things I want to tweak with it though over the offseason. I've had a handful of ideas of ways I can adjust how it predicts and I'm looking forward to trying them. The biggest issue I have is ATS predictions. 47% is terrible and I'm hoping my ideas will improve everything, including ATS. I have a lot of ideas for the program as a whole that I wasn't going to make mid season because I was really busy with work and didn't have the time to commit to making big changes.
* I really need to automate the results portion of this. Every Sunday morning spent filling in results was tedious at times. It was kind of relaxing but man I can't keep that up forever.
* As part of the previous point I need a way to pull betting data from somewhere. At the moment I just get it from the ESPN game summary page (i.e. on the bottom left of [this page](https://www.espn.com/college-football/game/_/gameId/401442010) is the Line and Over/Under) and type everything in myself and then do some quick mental math to check results.
 
### TODO List (Updated 1/10/2023)

1. Automate results of weekly predictions (this is even more important now that I've done a full season of updating this manually lol). This step includes getting betting data from some source online

2. Tweak/improve/adjust prediction algorithm to a point where I'm happy with it. After the 2022 season (where I ran it for every game for the first time) I noticed some trends/patterns in the predictions which has given me some ideas to improve it.

3. More print-outs: conference average rating, conference top to bottom rating+ranking, conference ranking, division ranking, etc.

4. Add a UI.  This is currently a command line project.  I want to add a UI with dropdowns for the season and sections for outputs and stuff.
	
5. Add improvements for early season ratings (recruiting info, returning production stats, etc. (not sure where to get this data though))

6. ????

### Misc.

**The Best and Worst of all Time!**

My poll, as of this update, has been run across every season from 2000 through 2022 (that's because sports-reference only goes back to the year 2000) (using my new rating formula, meaning the ratings from all previous posts aren't totally accurate to what you'll see here, but the formula is way better now, trust me)

Something I noticed across these seasons is that the best teams had a rating above 40 and the worst teams were below 16, so I made a list of them [here]( https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/Resources/BOAT%20and%20WOAT.xlsx).

I decided to split up the rankings between pre-CFP and CFP eras.  This was because the teams in the CFP would get little bumps from playing an extra game against an elite-level team.

*New additions for the 2022 season!*

* This year Georgia clocks in with a 42.124 in my poll, placing them at #3 in the Playoff Era
* No teams had a rating less than 16.  So no new additions.  The worst team of the season was Massachusetts with a rating of 17.236

**The top 5 Best of all Time (pre-CFP era)**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2001 | Miami FL | 42.309 | 12-0
2 | 2009 | Alabama | 41.756 | 14-0
3 | 2010 | Auburn | 41.464 | 14-0
4 | 2005 | Texas | 41.291 | 13-0
5 | 2000 | Oklahoma | 41.246 | 13-0

**The top 5 Best of all Time (CFP era)**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2018 | Clemson | 42.445 | 15-0
2 | 2019 | LSU | 42.374 | 15-0
3 | 2022 | Georgia | 42.124 | 15-0
4 | 2015 | Alabama | 41.615 | 14-1
5 | 2016 | Alabama | 41.061 | 14-1

**The bottom 5 Worst of all Time**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2019 | Akron | 13.370 | 0-12
2 | 2009 | EMU | 13.809 | 0-12
3 | 2004 | UCF | 13.954 | 0-11
4 | 2013 | Miami OH | 13.973 | 0-12
5 | 2006 | FIU | 14.394 | 0-12
