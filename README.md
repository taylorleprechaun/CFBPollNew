# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS)

### Recent changes

* 9/2/2024: Merged in start of some UI changes which I haven't worked on in idk like 8 months. Also made some fixes to typical early season issues due to incomplete/missing data.
* 9/3/2024: Slight adjustments to Predictions algorithm. Small code adjustments to improve the experience of running everything.
* 10/13/2024: Added strength of schedule to the info I post here

### Rankings (Updated 11/24/2024)

**Week 14 Rankings**

Rank | Team | Rating | Record | SoS | SoS Rank
---|---|---|---|---|---
1 | Oregon | 1.0000 | 11-0 | 0.5492 | 55
2 | Ohio State | 0.9643 | 10-1 | 0.5641 | 37
3 | Texas | 0.9458 | 10-1 | 0.5400 | 66
4 | SMU | 0.9377 | 10-1 | 0.5386 | 68
5 | Miami FL | 0.9330 | 10-1 | 0.5258 | 80
6 | Notre Dame | 0.9312 | 10-1 | 0.5408 | 64
7 | Indiana | 0.9242 | 10-1 | 0.5120 | 97
8 | Penn State | 0.9238 | 10-1 | 0.5161 | 91
9 | Georgia | 0.9125 | 9-2 | 0.5734 | 26
10 | Boise State | 0.9048 | 10-1 | 0.5173 | 89
11 | Alabama | 0.8984 | 8-3 | 0.6128 | 10
12 | Iowa State | 0.8817 | 9-2 | 0.5323 | 73
13 | Clemson | 0.8811 | 9-2 | 0.5259 | 79
14 | Brigham Young | 0.8803 | 9-2 | 0.5303 | 74
15 | South Carolina | 0.8612 | 8-3 | 0.5713 | 29
16 | Mississippi | 0.8597 | 8-3 | 0.5600 | 47
17 | Louisville | 0.8575 | 7-4 | 0.6339 | 3
18 | Arizona State | 0.8571 | 9-2 | 0.5017 | 108
19 | Tennessee | 0.8554 | 9-2 | 0.4926 | 113
20 | UNLV | 0.8539 | 9-2 | 0.5140 | 94
21 | Texas A&M | 0.8533 | 8-3 | 0.5638 | 39
22 | Kansas State | 0.8506 | 8-3 | 0.5616 | 45
23 | Syracuse | 0.8476 | 8-3 | 0.5624 | 43
24 | Illinois | 0.8436 | 8-3 | 0.5539 | 51
25 | Tulane | 0.8421 | 9-2 | 0.5171 | 90

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/2024-Week%2014.md)

#### Observations and Notes (Updated 10/13/2024)

* I decided to include my custom strength of schedule calculation in the info I post here because I've realized how much I talk about it and it might be nice for anyone who looks at this to be able to see what I'm talking about when I do. Last week I mentioned how some 1-loss teams were ranked higher than 0-loss teams because of how good their SoS is. And now you can see that too! Look at Texas Tech and Kansas State with the #5 and #13 ranked SoS. That's the biggest reason they're both in the top 6 ahead of teams like Pittsburgh, Miami FL, and Indiana who all have a SoS in the bottom 20.

#### Predictions (Updated 11/25/2024)

Week 14 Predictions: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/Predictions/2024-Week%2014.md)

Week 13 Results: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/Predictions/2024-Week%2013.md)

Results:
* Winner: 42 - 20 (67.7%)
* ATS: 30 - 32 (48.4%)
* O/U: 37 - 25 (59.7%)

Season Results:
* Winner: 426 - 199 (68.2%)
* ATS: 304 - 331 (47.9%)
* O/U: 317 - 318 (49.9%)

2023 Season Results:
* Winner: 507 - 232 (68.6%)
* ATS: 365 - 374 (49.4%)
* O/U: 366 - 373 (49.5%)

2022 Season Results:
* Winner: 485 - 240 (66.9%)
* ATS: 341 - 383 (47.1%)
* O/U: 372 - 352 (51.4%)

### TODO List (Updated 12/5/2023)

1. Tweak/improve/adjust prediction algorithm to a point where I'm happy with it. I found a [site](https://www.thepredictiontracker.com/ncaaresults.php) posted on r/CFB with the results of a bunch of predictive algorithms so I'll definitely use this as some benchmarks when updating my algorithm. As of writing this my outright picks are on the low end, my ATS picks are middle of the pack, and my RMSE is really really bad lol.

2. More print-outs: conference average rating, conference top to bottom rating+ranking, conference ranking, division ranking, etc.

3. Add a UI.  This is currently a command line project.  I want to add a UI with dropdowns for the season and sections for outputs and stuff.
	
4. Add improvements for early season ratings (recruiting info, returning production stats, etc. (not sure where to get this data though))

5. ????

### Misc.

**The Best and Worst of all Time!**

My poll, as of this update, has been run across every season from 2000 through 2022 (that's because sports-reference only goes back to the year 2000) (using my new rating formula, meaning the ratings from all previous posts aren't totally accurate to what you'll see here, but the formula is way better now, trust me)

Something I noticed across these seasons is that the best teams had a rating above 40 and the worst teams were below 16, so I made a list of them [here]( https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/Resources/BOAT%20and%20WOAT.xlsx).

I decided to split up the rankings between pre-CFP and CFP eras.  This was because the teams in the CFP would get little bumps from playing an extra game against an elite-level team.
I'm probably going to have to split the CFP era into 4 and 12 team sections but that's a problem for future me

*New additions for the 2023 season!*

* This year Michigan clocks in with a 42.244 in my poll, placing them at #3 in the Playoff Era
* This year Kent State clocks in with a 15.812 in my poll, placing them at 11th worst in the Playoff Era

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
3 | 2022 | Michigan | 42.244 | 15-0
4 | 2022 | Georgia | 42.124 | 15-0
5 | 2015 | Alabama | 41.615 | 14-1

**The bottom 5 Worst of all Time**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2019 | Akron | 13.370 | 0-12
2 | 2009 | EMU | 13.809 | 0-12
3 | 2004 | UCF | 13.954 | 0-11
4 | 2013 | Miami OH | 13.973 | 0-12
5 | 2006 | FIU | 14.394 | 0-12
